//using Biblioteca_Josias_83.Context;
//using Biblioteca_Josias_83.Models;
//using Biblioteca_Josias_83.Services;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace Biblioteca_Josias_83.Controllers
//{
//    public class AccountController : Controller
//    {
//        private readonly ApplicationDbContext _context;
//        private readonly JwtService _jwtService;

//        public AccountController(ApplicationDbContext context, JwtService jwtService)
//        {
//            _context = context;
//            _jwtService = jwtService;
//        }

//        // GET: Account/Register
//        public IActionResult Register()
//        {
//            return View();
//        }

//        // POST: Account/Register
//        // POST: Account/Register
//        [HttpPost]
//        public async Task<IActionResult> Register(Usuario usuario)
//        {
//            if (ModelState.IsValid)
//            {
//                // Asignar un rol por defecto
//                usuario.FkRol = 2; // Rol de usuario regular

//                _context.Usuarios.Add(usuario);
//                await _context.SaveChangesAsync();

//                // Generar token JWT
//                var token = _jwtService.GenerateToken(usuario);
//                Response.Cookies.Append("jwt", token, new CookieOptions
//                {
//                    HttpOnly = true,
//                    Secure = true, // Solo enviar en HTTPS
//                    SameSite = SameSiteMode.Strict
//                });

//                return RedirectToAction("Index", "Home");
//            }

//            // Asegúrate de pasar el modelo de vuelta si hay errores
//            return View(usuario);
//        }



//        // GET: Account/Login
//        public IActionResult Login()
//        {
//            return View();
//        }

//        // POST: Account/Login
//        [HttpPost]
//        public async Task<IActionResult> Login(string userName, string password)
//        {
//            var usuario = await _context.Usuarios
//     .Include(u => u.Roles)  // Asegúrate de que estás utilizando "Roles" en plural
//     .FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password);

//            if (usuario == null)
//            {
//                ViewBag.Error = "Usuario no encontrado";
//                return View();
//            }

//            // Verificar la contraseña hasheada
//            var passwordHasher = new PasswordHasher<Usuario>();
//            var result = passwordHasher.VerifyHashedPassword(usuario, usuario.Password, password);

//            if (result != PasswordVerificationResult.Success)
//            {
//                ViewBag.Error = "Contraseña incorrecta";
//                return View();
//            }

//            // Generar token JWT
//            var token = _jwtService.GenerateToken(usuario);
//            Response.Cookies.Append("jwt", token, new CookieOptions
//            {
//                HttpOnly = true,
//                Secure = true, // Solo enviar en HTTPS
//                SameSite = SameSiteMode.Strict
//            });

//            return RedirectToAction("Index", "Home");
//        }

//        // GET: Account/Logout
//        public IActionResult Logout()
//        {
//            Response.Cookies.Delete("jwt");
//            return RedirectToAction("Login");
//        }
//    }
//}
