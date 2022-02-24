using LibApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        Book Get(int id);
        void Add(Book book);
        void Remove(int id);
        void Update(Book book);
        void Save();

    }
}
