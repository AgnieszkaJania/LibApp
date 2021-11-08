using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibApp.Models;
using LibApp.ViewModels;

namespace LibApp.Controllers
{
    public class BooksController : Controller
    {
       //GET /Books/Random

        public IActionResult Random()
        {
            var firstBook = new Book() { Name = "English dictionary" };

            var customers = new List<Customer>
            {
                new Customer{Name = "Customer 1" },
                new Customer{Name = "Customer 2" }
            };

            var viewModel = new RandomBookViewModel
            {
                Book = firstBook,
                Customers = customers
                
            };

            return View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            return Content("id " + id);
        }

        public IActionResult Index()
        {
            //if (!pageIndex.HasValue)
            //{
            //    pageIndex = 1;
            //}
            //if (String.IsNullOrEmpty(sortBy))
            //{
            //    sortBy = "Name";
            //}

            //return Content($"pageIndex = {pageIndex} & sortBy = {sortBy}");
            //end
            var books = GetBooks();
            return View(books);

        }
        [Route("books/released/{year:regex(^\\d{{4}}$)}/{month:range(1,12)}")]
        public IActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
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
