using System;
using Biblioteca_Josias_83.Context;
using Biblioteca_Josias_83.Models.Domain;
using Biblioteca_Josias_83.Services.IServices;

namespace Biblioteca_Josias_83.Services.Services
{
    public class CategoryService : ICategoryServices
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Categoria> GetCategories()
        {
            try
            {
                return _context.Categorias.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al obtener las categorías: " + ex.Message);
            }
        }
        public Categoria GetCategory(int id)
        {
            try
            {
                Categoria result = _context.Categorias.Find(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al obtener la categoría" + ex.Message);
            }
        }

        public bool CreateCategory(Categoria request)
        {
            try
            {
                Categoria categoria = new Categoria
                {
                    Nombre = request.Nombre
                };

                _context.Categorias.Add(categoria);
                int result = _context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al crear la categoría: " + ex.Message);
            }
        }

        public bool UpdateCategory(Categoria request)
        {
            try
            {
                Categoria categoria = _context.Categorias.Find(request.PkCategoria);
                if (categoria == null)
                {
                    throw new Exception("Categoría no encontrada");
                }

                categoria.Nombre = request.Nombre;

                _context.Categorias.Update(categoria);
                int result = _context.SaveChanges();
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al actualizar la categoría: " + ex.Message);
            }
        }

        public bool DeleteCategory(int id)
        {
            try
            {
                var categoria = _context.Categorias.Find(id);
                if (categoria == null)
                {
                    throw new Exception("Categoría no encontrada");
                }

                _context.Categorias.Remove(categoria);
                int result = _context.SaveChanges();
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al eliminar la categoría: " + ex.Message);
            }
        }
    }
}

