using System;
using Biblioteca_Josias_83.Services.IServices;
using Biblioteca_Josias_83.Services.Services;
using Biblioteca_Josias_83.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca_Josias_83.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRolServices _rolServices;

        public RoleController(IRolServices rolServices)
        {
            _rolServices = rolServices;
        }
        public IActionResult IndexRoles()
        {
            var result = _rolServices.GetRoles();
            return View(result);
        }
        [HttpGet]
        public IActionResult CrearRol()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CrearRol(Rol request)
        {
            _rolServices.CreateRol(request);

            return RedirectToAction("IndexRoles");
        }

        [HttpGet]
        public IActionResult EditarRol(int id)
        {
            var rol = _rolServices.GetRol(id);
            if (rol == null)
            {
                return NotFound();
            }
            return View(rol);
        }

        [HttpPost]
        public IActionResult EditarRol(Rol request)
        {
            bool isUpdated = _rolServices.UpdateRol(request);
            if (isUpdated)
            {
                return RedirectToAction("IndexRoles");
            }
            return View(request);
        }



        [HttpDelete]
        public IActionResult EliminarRol(int id)
        {
            bool result = _rolServices.DeleteRol(id);
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

