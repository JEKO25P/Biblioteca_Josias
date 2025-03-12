using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca_Josias_83.Models;
using Biblioteca_Josias_83.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Biblioteca_Josias_83.Controllers
{
    [Authorize(Roles = "Usuario")] // Solo accesible para el rol "Usuario"
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
    public class UsuarioController : Controller
    {

        //creamos el constructor para acceder a los usuarios
        private readonly IUsuarioServices _usuarioServices;
        public UsuarioController(IUsuarioServices usuarioServices)

        {
            _usuarioServices = usuarioServices;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            var result = _usuarioServices.ObtenerUsuario();
            return View(result);
        }

        [HttpGet]
        public IActionResult Crear()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Crear(Usuario request)
        {
            _usuarioServices.CrearUsuario(request);

            return RedirectToAction("index");
        }


        [HttpGet]
        public IActionResult Editar(int id )
        {
            var result = _usuarioServices.GetUsuarioById(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(Usuario request)
        {
            bool isUpdate = await _usuarioServices.EditarUsuario(request);
            if (isUpdate)
            {
                return RedirectToAction("index");
            }
            ModelState.AddModelError("", "Ocurrio un error  al actualizar el usuario");
            return View(request);
        }

        //[HttpPost]
        //public IActionResult Eliminar(int id)
        //{
        //    _usuarioServices.EliminarUsuario(id);
        //    return RedirectToAction("index");

        //}

        [HttpDelete]
        [Route("Usuario/Eliminar/{id}")]
        public IActionResult Eliminar(int id)
        {
            bool result = _usuarioServices.EliminarUsuario(id);
            return Json(new { success = result });
        }




    }
}

