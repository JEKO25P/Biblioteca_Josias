using Biblioteca_Josias_83.Models;
using Biblioteca_Josias_83.Models.Domain;
using Biblioteca_Josias_83.Services.IServices;
using Biblioteca_Josias_83.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca_Josias_83.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorServices _authorServices;

        public AuthorController(IAuthorServices authorServices)
        {
            _authorServices = authorServices;
        }
        public IActionResult IndexAutores()
        {
            var result = _authorServices.GetAuthors();
            return View(result);
        }
        [HttpGet]
        public IActionResult CrearAutor()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CrearAutor(Autor request, IFormFile FotoFile)
        {
            if (FotoFile != null && FotoFile.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    FotoFile.CopyTo(ms);
                    request.Foto = ms.ToArray();  // Convertimos la imagen a byte[]
                }
            }
            _authorServices.CreateAuthor(request);

            return RedirectToAction("IndexAutores");
        }

        [HttpGet]
        public IActionResult EditarAutor(int id)
        {
            var autor = _authorServices.GetAuthor(id);
            if (autor == null)
            {
                return NotFound();
            }
            return View(autor);
        }

        [HttpPost]
        public IActionResult EditarAutor(Autor request, IFormFile FotoFile)
        {
            if (FotoFile != null && FotoFile.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    FotoFile.CopyTo(ms);
                    request.Foto = ms.ToArray();  // Convertimos la imagen a byte[]
                }
            }
            else if (request.Foto == null)
            {
                // Si no se seleccionó nueva imagen, mantener la imagen existente
                var existingAuthor = _authorServices.GetAuthor(request.PkAutor);
                request.Foto = existingAuthor.Foto;  // Mantener la imagen original
            }
            bool isUpdated = _authorServices.UpdateAuthor(request);
            if (isUpdated)
            {
                return RedirectToAction("IndexAutores");
            }
            return View(request);
        }

        [HttpDelete]
        public IActionResult EliminarAutor(int id)
        {
            bool result = _authorServices.DeleteAuthor(id);
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

