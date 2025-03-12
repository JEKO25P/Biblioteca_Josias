using Microsoft.AspNetCore.Mvc;
using Biblioteca_Josias_83.Context;
using Biblioteca_Josias_83.Models;
using System.Linq;

namespace Biblioteca_Josias_83.Controllers
{
    public class LibroController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LibroController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var libros = _context.Libros.ToList();
            return View(libros);
        }
    }
}
