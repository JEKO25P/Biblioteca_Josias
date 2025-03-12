using Microsoft.AspNetCore.Mvc;

namespace Biblioteca_Josias_83.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AdminDashboard()
        {
            return View();
        }
    }
}