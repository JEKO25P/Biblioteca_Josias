using System;
using Biblioteca_Josias_83.Models.Domain;

namespace Biblioteca_Josias_83.Services.IServices
{
    public interface ICategoryServices
    {
        List<Categoria> GetCategories();
        public bool CreateCategory(Categoria request);
        public Categoria GetCategory(int id);
        public bool UpdateCategory(Categoria request);
        public bool DeleteCategory(int id);
    }
}

