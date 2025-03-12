using System;
using Biblioteca_Josias_83.Models;
using Biblioteca_Josias_83.Models.Domain;
using Biblioteca_Josias_83.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca_Josias_83.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly IRolServices _rolServices;
        public UserController(IUserServices userServices, IRolServices rolServices)
        {
            _userServices = userServices;
            _rolServices = rolServices;
        }

        public IActionResult Index()
        {
            var result = _userServices.GetUsuarios();
            return View(result);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            var roles = _rolServices.GetRoles();
            ViewBag.Roles = roles;

            return View();
        }

        [HttpPost]
        public IActionResult Crear(Usuario request)
        {
            _userServices.CreateUser(request);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var usuario = _userServices.GetUser(id);
            if (usuario == null)
            {
                return NotFound();
            }

            var roles = _rolServices.GetRoles();
            ViewBag.Roles = roles;

            return View(usuario);
        }

        [HttpPost]
        public IActionResult Editar(Usuario request)
        {
            bool isUpdated = _userServices.UpdateUser(request);
            if (isUpdated)
            {
                return RedirectToAction("Index");
            }
            return View(request);
        }

        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            bool result = _userServices.DeleteUser(id);
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
