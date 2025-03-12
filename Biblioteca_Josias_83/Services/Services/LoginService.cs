using System;
using Biblioteca_Josias_83.Services.IServices;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Biblioteca_Josias_83.Services.Services
{
    public class LoginService : ILoginServices
    {
        private readonly IUserServices _userServices;
        private readonly IConfiguration _config;

        public LoginService(IUserServices userServices, IConfiguration config)
        {
            _userServices = userServices;
            _config = config;
        }

        public string Authenticate(string username, string password)
        {
            // Paso 1: Buscar el usuario por su UserName
            var user = _userServices.GetUsuarios()
                .FirstOrDefault(u => u.UserName == username);

            // Paso 2: Verificar que el usuario exista
            if (user == null)
            {
                return null; // Usuario no encontrado
            }

            // Paso 3: Comparar la contraseña ingresada con el hash almacenado
            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return null; // Contraseña incorrecta
            }

            // Paso 4: Generar el token JWT si las credenciales son válidas
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.Role, user.Roles.Nombre), // Añade el rol del usuario
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}

