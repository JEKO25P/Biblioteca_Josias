using System;
using Biblioteca_Josias_83.Context;
using Biblioteca_Josias_83.Models.Domain;
using Biblioteca_Josias_83.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_Josias_83.Services.Services
{
    public class AuthorService : IAuthorServices
    {
        private readonly ApplicationDbContext _context;

        public AuthorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Autor> GetAuthors()
        {
            try
            {
                return _context.Autores.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al obtener los autores: " + ex.Message);
            }
        }
        public Autor GetAuthor(int id)
        {
            try
            {
                Autor result = _context.Autores.Find(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al obtener el autor" + ex.Message);
            }
        }

        public bool CreateAuthor(Autor request)
        {
            try
            {
                if (request == null)
                {
                    throw new ArgumentNullException(nameof(request), "El objeto Autor proporcionado es nulo.");
                }

                if (string.IsNullOrEmpty(request.Nombre))
                {
                    throw new ArgumentException("El campo Nombre no puede estar vacío.", nameof(request.Nombre));
                }

                if (request.Foto == null || request.Foto.Length == 0)
                {
                    throw new ArgumentException("El campo Foto no puede estar vacío o nulo.");
                }

                if (string.IsNullOrEmpty(request.Descripcion))
                {
                    throw new ArgumentException("El campo Descripción no puede estar vacío.", nameof(request.Descripcion));
                }

                // Crear el nuevo autor
                Autor autor = new Autor
                {
                    Nombre = request.Nombre,
                    Foto = request.Foto,
                    Descripcion = request.Descripcion
                };

                _context.Autores.Add(autor);
                int result = _context.SaveChanges();

                if (result <= 0)
                {
                    throw new Exception("No se guardaron cambios en la base de datos.");
                }

                return true;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception($"Error al crear el autor: Se proporcionó un argumento nulo. Detalles: {ex.Message}", ex);
            }
            catch (ArgumentException ex)
            {
                throw new Exception($"Error al crear el autor: Validación de datos fallida. Detalles: {ex.Message}", ex);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Error al crear el autor: Falló la actualización en la base de datos. Verifica la estructura de la tabla 'Autores'. Detalles: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error general al crear el autor: {ex.Message}", ex);
            }
        }


        public bool UpdateAuthor(Autor request)
        {
            try
            {
                if (request == null)
                {
                    throw new ArgumentNullException(nameof(request), "El objeto Autor proporcionado es nulo.");
                }

                if (request.PkAutor <= 0)
                {
                    throw new ArgumentException("El identificador del autor (PkAutor) no es válido.", nameof(request.PkAutor));
                }

                Autor autor = _context.Autores.Find(request.PkAutor);
                if (autor == null)
                {
                    throw new KeyNotFoundException($"No se encontró un autor con el ID {request.PkAutor}.");
                }

                // Validaciones de datos
                if (!string.IsNullOrEmpty(request.Nombre))
                {
                    autor.Nombre = request.Nombre;
                }

                if (request.Foto != null && request.Foto.Length > 0)
                {
                    autor.Foto = request.Foto;
                }

                if (!string.IsNullOrEmpty(request.Descripcion))
                {
                    autor.Descripcion = request.Descripcion;
                }

                _context.Autores.Update(autor);
                int result = _context.SaveChanges();

                if (result <= 0)
                {
                    throw new Exception("No se guardaron cambios en la base de datos.");
                }

                return true;
            }
            catch (KeyNotFoundException ex)
            {
                throw new Exception($"Error al actualizar el autor: {ex.Message}", ex);
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception($"Error al actualizar el autor: Se proporcionó un argumento nulo. Detalles: {ex.Message}", ex);
            }
            catch (ArgumentException ex)
            {
                throw new Exception($"Error al actualizar el autor: Validación de datos fallida. Detalles: {ex.Message}", ex);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Error al actualizar el autor: Falló la actualización en la base de datos. Verifica la estructura de la tabla 'Autores'. Detalles: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error general al actualizar el autor: {ex.Message}", ex);
            }
        }


        public bool DeleteAuthor(int id)
        {
            try
            {
                var autor = _context.Autores.Find(id);
                if (autor == null)
                {
                    throw new Exception("Autor no encontrada");
                }

                _context.Autores.Remove(autor);
                int result = _context.SaveChanges();
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al eliminar el autor: " + ex.Message);
            }
        }
    }
}

