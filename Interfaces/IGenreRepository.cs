using LibApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Interfaces
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetGenres();
        Genre Get(int id);
        void Add(Genre genre);
        void Remove(int id);
        void Update(Genre genre);
        void Save();
    }
}
