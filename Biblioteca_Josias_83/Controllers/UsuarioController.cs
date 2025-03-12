using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca_Josias_83.Models.Domain;
using Biblioteca_Josias_83.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Biblioteca_Josias_83.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IBookServices _bookServices;
        private readonly IAuthorServices _authorServices;

        public UsuarioController(IBookServices bookServices, IAuthorServices authorServices)
        {
            _bookServices = bookServices;
            _authorServices = authorServices;
        }

        // Acción para el Home (3 libros y 3 autores como cards)
        [HttpGet]
        public IActionResult Home()
        {
            var libros = _bookServices.GetBooks().Take(3).ToList(); // Toma 3 libros
            var autores = _authorServices.GetAuthors().Take(3).ToList(); // Toma 3 autores

            ViewBag.Libros = libros;
            ViewBag.Autores = autores;

            return View();
        }

        // Acción para listar todos los libros (como cards)
        [HttpGet]
        public IActionResult Libros()
        {
            var libros = _bookServices.GetBooks(); // Lista todos los libros
            return View(libros);
        }

        // Acción para ver un libro específico (detalles completos)
        [HttpGet]
        public IActionResult VerLibro(int id)
        {
            var libro = _bookServices.GetBook(id); // Busca el libro por ID
            if (libro == null)
            {
                return NotFound("El libro no fue encontrado.");
            }
            return View(libro);
        }

        // Acción para listar todos los autores (como cards)
        [HttpGet]
        public IActionResult Autores()
        {
            var autores = _authorServices.GetAuthors(); // Lista todos los autores
            return View(autores);
        }
    }
}

