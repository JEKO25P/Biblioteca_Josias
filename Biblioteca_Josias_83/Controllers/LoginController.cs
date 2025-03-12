using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Biblioteca_Josias_83.Models;
using Biblioteca_Josias_83.Models.Domain;
using Biblioteca_Josias_83.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca_Josias_83.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginServices _loginService;

        public LoginController(ILoginServices loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(); // Renderiza la vista de inicio de sesión
        }

        [HttpPost]
        public IActionResult Authenticate(LoginRequest request)
        {
            // Paso 1: Autenticación con el servicio
            var token = _loginService.Authenticate(request.Username, request.Password);

            if (string.IsNullOrEmpty(token))
            {
                // Paso 2: Mostrar mensaje de error si las credenciales no son válidas
                ViewBag.ErrorMessage = "Credenciales inválidas";
                return View("Login");
            }

            // Paso 3: Extraer rol del usuario del token
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var role = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            // Paso 4: Redirigir según el rol
            if (role == "Administrador")
            {
                return RedirectToAction("AdminDashboard", "Admin");
            }
            else if (role == "Usuario")
            {
                return RedirectToAction("Home", "Usuario");
            }

            // Si el rol no es válido, redirigir al login
            ViewBag.ErrorMessage = "Rol no válido";
            return View("Login");
        }
        [HttpPost]
        public IActionResult Logout()
        {
            // Eliminar cualquier cookie o sesión relacionada con el usuario
            HttpContext.Response.Cookies.Delete("JwtToken"); // Si estás usando cookies

            // Redirigir al login
            return RedirectToAction("Login", "Login");
        }

    }
}