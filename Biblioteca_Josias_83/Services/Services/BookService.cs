using System;
using Biblioteca_Josias_83.Context;
using Biblioteca_Josias_83.Models;
using Biblioteca_Josias_83.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_Josias_83.Services.Services
{
    [Authorize(Policy = "Administrador")] // Solo administradores pueden acceder
    public class BookService : IBookServices
    {
        private readonly ApplicationDbContext _context;

        public BookService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Libro> GetBooks()
        {
            try
            {
                List<Libro> result = _context.Libros.Include(x => x.Autores).Include(y => y.Categorias).ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error" + ex.Message);
            }
        }

        public Libro GetBook(int id)
        {
            try
            {
                Libro result = _context.Libros.Find(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error" + ex.Message);
            }
        }

        public bool CreateBook(Libro request)
        {
            try
            {
                Libro libro = new Libro
                {
                    Titulo = request.Titulo,
                    Descripcion = request.Descripcion,
                    Imagen = request.Imagen,  // Guardamos la imagen como byte[]
                    AñoPublicacion = request.AñoPublicacion,
                    Editorial = request.Editorial,
                    UrlLectura = request.UrlLectura,
                    FkAutor = request.FkAutor,
                    FkCategoria = request.FkCategoria
                };

                _context.Libros.Add(libro);
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al guardar el libro: " + ex.Message);
            }
        }


        public bool UpdateBook(Libro request)
        {
            try
            {
                Libro libro = _context.Libros.Find(request.PkLibro);
                if (libro == null)
                {
                    throw new Exception("Libro no encontrado");
                }

                libro.Titulo = request.Titulo;
                libro.Descripcion = request.Descripcion;
                libro.Imagen = request.Imagen;
                libro.AñoPublicacion = request.AñoPublicacion;
                libro.Editorial = request.Editorial;
                libro.UrlLectura = request.UrlLectura;
                libro.FkAutor = request.FkAutor;
                libro.FkCategoria = request.FkCategoria;

                _context.Libros.Update(libro);
                int result = _context.SaveChanges();
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al actualizar el libro: " + ex.Message);
            }
        }

        public bool DeleteBook(int id)
        {
            try
            {
                var libro = _context.Libros.Find(id);
                if (libro == null)
                {
                    throw new Exception("Libro no encontrado");
                }

                _context.Libros.Remove(libro);
                int result = _context.SaveChanges();
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al eliminar el libro: " + ex.Message);
            }
        }
    }
}

