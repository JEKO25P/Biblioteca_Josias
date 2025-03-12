using Biblioteca_Josias_83.Models;
using Biblioteca_Josias_83.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca_Josias_83.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookServices _bookServices;
        private readonly IAuthorServices _authorServices;
        private readonly ICategoryServices _categoryServices;
        public BookController(IBookServices bookServices, IAuthorServices authorServices, ICategoryServices categoryServices)
        {
            _bookServices = bookServices;
            _authorServices = authorServices;
            _categoryServices = categoryServices;
        }
        public IActionResult IndexLibros()
        {
            var result = _bookServices.GetBooks();
            return View(result);
        }
        [HttpGet]
        public IActionResult CrearLibro()
        {
            var autores = _authorServices.GetAuthors();
            ViewBag.Autores = autores;

            var categorias = _categoryServices.GetCategories();
            ViewBag.Categorias = categorias;

            return View();
        }


        [HttpPost]
        public IActionResult CrearLibro(Libro request, IFormFile ImagenFile)
        {
            try
            {
                if (ImagenFile != null && ImagenFile.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        ImagenFile.CopyTo(ms);
                        request.Imagen = ms.ToArray();  // Convertimos la imagen a byte[]
                    }
                }

                bool creado = _bookServices.CreateBook(request);

                if (creado)
                {
                    return RedirectToAction("IndexLibros");
                }

                return BadRequest("Error al guardar el libro.");
            }
            catch (Exception ex)
            {
                return BadRequest("Error al guardar el libro: " + ex.Message);
            }
        }


        [HttpGet]
        public IActionResult EditarLibros(int id)
        {
            var libro = _bookServices.GetBook(id);
            if (libro == null)
            {
                return NotFound();
            }

            var autores = _authorServices.GetAuthors();
            ViewBag.Autores = autores;

            var categorias = _categoryServices.GetCategories();
            ViewBag.Categorias = categorias;

            return View(libro);
        }

        [HttpPost]
        public IActionResult EditarLibros(Libro request, IFormFile ImagenFile)
        {
            try
            {
                // Si se seleccionó una nueva imagen, guardarla
                if (ImagenFile != null && ImagenFile.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        ImagenFile.CopyTo(ms);
                        request.Imagen = ms.ToArray();  // Convertimos la imagen a byte[]
                    }
                }
                else if (request.Imagen == null)
                {
                    // Si no se seleccionó nueva imagen, mantener la imagen existente
                    var existingBook = _bookServices.GetBook(request.PkLibro);
                    request.Imagen = existingBook.Imagen;  // Mantener la imagen original
                }

                bool isUpdated = _bookServices.UpdateBook(request);

                if (isUpdated)
                {
                    return RedirectToAction("IndexLibros");
                }

                return BadRequest("Error al actualizar el libro.");
            }
            catch (Exception ex)
            {
                return BadRequest("Error al actualizar el libro: " + ex.Message);
            }
        }



        [HttpDelete]
        public IActionResult EliminarLibro(int id)
        {
            bool result = _bookServices.DeleteBook(id);
            if (result == true)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }
    }
}

