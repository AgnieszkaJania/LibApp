using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibApp.Models;
using LibApp.ViewModels;
using LibApp.Data;
using Microsoft.EntityFrameworkCore;


namespace LibApp.Controllers
{   
    public class BooksController : Controller
    {
        //GET /Books/Random
        private readonly ApplicationDbContext _context;
        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }
        

        public IActionResult Edit(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);
            if(book == null)
            {
                return NotFound();
            }

            var viewModel = new BookFormViewModel
            {
                Book = book,
                Genres = _context.Genre.ToList()
            };
            return View("BookForm", viewModel);
        }

        public IActionResult New()
        {
            var viewModel = new BookFormViewModel
            {
                Genres = _context.Genre.ToList()
            };
            return View("BookForm", viewModel); 
        }
        [HttpPost]
        public IActionResult Save(Book book)
        {
            if(book.Id == 0)
            {
                book.DateAdded = DateTime.Now;
                _context.Books.Add(book);
            }
            else
            {
                var bookInDb = _context.Books.Single(b => b.Id == book.Id);
                bookInDb.Name = book.Name;
                bookInDb.AuthorName = book.AuthorName;
                bookInDb.GenreId = book.GenreId;
                bookInDb.ReleaseDate = book.ReleaseDate;
                bookInDb.DateAdded = book.DateAdded;
                bookInDb.NumberInStock = book.NumberInStock;
            }
            try
            {
                _context.SaveChanges();
            }
            catch(DbUpdateException e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Index","Books");
        }

        public IActionResult Index()
        {

            var books = _context.Books
                .Include(c => c.Genre)
                .ToList();
            return View(books);

        }
        public IActionResult Details(int id)
        {

            var book = _context.Books
                .Include(b => b.Genre)
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
