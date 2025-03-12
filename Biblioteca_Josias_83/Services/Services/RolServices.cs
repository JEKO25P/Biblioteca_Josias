using System;
using Biblioteca_Josias_83.Context;
using Biblioteca_Josias_83.Models;
using Biblioteca_Josias_83.Services.IServices;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace Biblioteca_Josias_83.Services.Services
{
    public class RolServices : IRolServices
    {
        private readonly ApplicationDbContext _context;

        public RolServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Rol> GetRoles()
        {
            try
            {
                return _context.Roles.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al obtener los roles: " + ex.Message);
            }
        }
        public Rol GetRol(int id)
        {
            try
            {
                Rol result = _context.Roles.Find(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al obtener el rol" + ex.Message);
            }
        }

        public bool CreateRol(Rol request)
        {
            try
            {
                Rol rol = new Rol
                {
                    Nombre = request.Nombre
                };

                _context.Roles.Add(rol);
                int result = _context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al crear el rol: " + ex.Message);
            }
        }

        public bool UpdateRol(Rol request)
        {
            try
            {
                Rol rol = _context.Roles.Find(request.PkRol);
                if (rol == null)
                {
                    throw new Exception("Rol no encontrado");
                }

                rol.Nombre = request.Nombre;

                _context.Roles.Update(rol);
                int result = _context.SaveChanges();
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al actualizar el rol: " + ex.Message);
            }
        }

        public bool DeleteRol(int id)
        {
            try
            {
                var rol = _context.Roles.Find(id);
                if (rol == null)
                {
                    throw new Exception("Rol no encontrado");
                }

                _context.Roles.Remove(rol);
                int result = _context.SaveChanges();
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al eliminar el rol: " + ex.Message);
            }
        }
    }
}

