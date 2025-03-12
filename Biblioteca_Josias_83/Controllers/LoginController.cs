using Microsoft.AspNetCore.Mvc;
using Biblioteca_Josias_83.Models;
using Biblioteca_Josias_83.Services;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

public class LoginController : Controller
{
    private readonly JwtService _jwtService;

    public LoginController(JwtService jwtService)
    {
        _jwtService = jwtService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(Usuario usuario)
    {
        if (usuario.UserName == "admin" && usuario.Password == "123")
        {
            // Generar un token JWT
            var token = _jwtService.GenerateToken(usuario.UserName, "Admin");

            // Guardar el token en una cookie (opcional)
            Response.Cookies.Append("jwt", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true, // Solo en HTTPS
                SameSite = SameSiteMode.Strict
            });

            // Redirigir al Home/Index
            return RedirectToAction("Index", "Home");
        }

        ViewBag.Error = "Usuario o contraseña incorrectos";
        return View();
    }
}