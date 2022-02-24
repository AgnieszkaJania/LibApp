using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibApp.Models;
using LibApp.ViewModels;
using LibApp.Data;
using Microsoft.EntityFrameworkCore;
using LibApp.Interfaces;

namespace LibApp.Controllers
{   
    public class BooksController : Controller
    {
        //GET /Books/Random
        private readonly IBookRepository _bookRepository;
        private readonly IGenreRepository _genreRepository;

        public BooksController(IGenreRepository genreRepository, IBookRepository bookRepository)
        {
            _genreRepository = genreRepository;
            _bookRepository = bookRepository;
        }


        public IActionResult Edit(int id)
        {
            var book = _bookRepository.Get(id);

            if(book == null)
            {
                return NotFound();
            }

            var viewModel = new BookFormViewModel
            {
                Book = book,
                Genres = _genreRepository.GetGenres()
            };
            return View("BookForm", viewModel);
        }

        public IActionResult New()
        {
            var viewModel = new BookFormViewModel
            {
                Genres = _genreRepository.GetGenres()
            };
            return View("BookForm", viewModel); 
        }
        [HttpPost]
        public IActionResult Save(Book book)
        {
            if(book.Id == 0)
            {
                book.DateAdded = DateTime.Now;
                _bookRepository.Add(book);
            }
            else
            {
                var bookInDb = _bookRepository.Get(book.Id);
                bookInDb.Name = book.Name;
                bookInDb.AuthorName = book.AuthorName;
                bookInDb.GenreId = book.GenreId;
                bookInDb.ReleaseDate = book.ReleaseDate;
                bookInDb.DateAdded = book.DateAdded;
                bookInDb.NumberInStock = book.NumberInStock;
            }
            try
            {
                _bookRepository.Save();
            }
            catch(DbUpdateException e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Index","Books");
        }

        public IActionResult Index()
        {

            var books = _bookRepository.GetBooks()
                .ToList();

            return View(books);

        }
        public IActionResult Details(int id)
        {

            var book = _bookRepository.GetBooks()
                .SingleOrDefault(b => b.Id == id);
            return View(book);

        }
       

        private IEnumerable<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book{ Id = 1, Name = "Hamlet"},
                new Book {Id = 2, Name = "Ulysses"}
            };
        }
    }
}
