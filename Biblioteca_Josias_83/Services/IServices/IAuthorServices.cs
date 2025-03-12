using System;
using Biblioteca_Josias_83.Models.Domain;

namespace Biblioteca_Josias_83.Services.IServices
{
    public interface IAuthorServices
    {
        List<Autor> GetAuthors();
        public bool CreateAuthor(Autor request);
        public Autor GetAuthor(int id);
        public bool UpdateAuthor(Autor request);
        public bool DeleteAuthor(int id);
    }
}

