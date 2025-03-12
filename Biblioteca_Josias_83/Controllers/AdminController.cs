using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca_Josias_83.Controllers
{
    [Authorize(Roles = "Admin")] // Solo accesible para el rol "Admin"
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}