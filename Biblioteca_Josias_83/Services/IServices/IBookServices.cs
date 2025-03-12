using System;
using Biblioteca_Josias_83.Models;

namespace Biblioteca_Josias_83.Services.IServices
{
    public interface IBookServices
    {
        List<Libro> GetBooks();
        public bool CreateBook(Libro request);
        public Libro GetBook(int id);
        public bool UpdateBook(Libro request);
        public bool DeleteBook(int id);
    }
}

