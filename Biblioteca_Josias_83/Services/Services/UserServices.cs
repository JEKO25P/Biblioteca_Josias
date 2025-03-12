using System;
using Biblioteca_Josias_83.Context;
using Biblioteca_Josias_83.Models;
using Biblioteca_Josias_83.Models.Domain;
using Biblioteca_Josias_83.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_Josias_83.Services.Services
{
    public class UserServices : IUserServices
    {
        private readonly ApplicationDbContext _context;

        public UserServices(ApplicationDbContext context)
        {
            _context = context;
        }

        //Obtener usuarios
        public List<Usuario> GetUsuarios()
        {
            try
            {
                List<Usuario> result = _context.Usuarios.Include(x => x.Roles).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error: " + ex.Message);
            }
        }

        public Usuario GetUser(int id)
        {
            try
            {
                Usuario result = _context.Usuarios.Find(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error: " + ex.Message);
            }
        }

        public bool CreateUser(Usuario request)
        {
            if (_context.Usuarios.Any(u => u.UserName == request.UserName))
            {
                throw new Exception("El nombre de usuario ya existe");
            }

            Usuario usuario = new Usuario
            {
                Nombre = request.Nombre,
                UserName = request.UserName,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                FkRol = request.FkRol
            };

            _context.Usuarios.Add(usuario);
            return _context.SaveChanges() > 0;
        }


        public bool UpdateUser(Usuario request)
        {
            var usuario = _context.Usuarios.Find(request.PkUsuario);
            if (usuario == null)
            {
                throw new Exception("Usuario no encontrado");
            }

            usuario.Nombre = request.Nombre;
            usuario.UserName = request.UserName;

            if (!string.IsNullOrEmpty(request.Password))
            {
                usuario.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
            }

            usuario.FkRol = request.FkRol;
            _context.Usuarios.Update(usuario);

            return _context.SaveChanges() > 0; // Simplificado
        }


        public bool DeleteUser(int id)
        {
            try
            {
                var usuario = _context.Usuarios.Find(id);
                if (usuario == null)
                {
                    throw new Exception("Usuario no encontrado");
                }

                _context.Usuarios.Remove(usuario);
                int result = _context.SaveChanges();
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al eliminar el usuario: " + ex.Message);
            }
        }
    }
}

