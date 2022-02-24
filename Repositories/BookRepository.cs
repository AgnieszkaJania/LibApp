using LibApp.Data;
using LibApp.Interfaces;
using LibApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetBooks()
        {
            return _context.Books.Include(book => book.Genre);
        }

        public Book Get(int id)
        {
            var book = _context.Books.Find(id);
            book.Genre = _context.Genre.Find(book.GenreId);
            return book;
        }
        public void Add(Book book)
        {
            _context.Books.Add(book);
        }
        public void Remove(int id)
        {
            _context.Books.Remove(Get(id));
        }
        public void Update(Book book)
        {
            _context.Books.Update(book);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
      
    }
}
