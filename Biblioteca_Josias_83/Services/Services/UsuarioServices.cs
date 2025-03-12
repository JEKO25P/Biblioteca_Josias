using System;
using Biblioteca_Josias_83.Context;
using Biblioteca_Josias_83.Models;
using Biblioteca_Josias_83.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_Josias_83.Services.Services
{
	public class UsuarioServices : IUsuarioServices
	{
		private readonly ApplicationDbContext _context;
		public UsuarioServices(ApplicationDbContext context)
		{
			_context = context;
		}

		public bool CrearUsuario(Usuario request)
		{
			try
			{
				Usuario usuario = new Usuario()
				{
					Nombre = request.Nombre,
					UserName = request.UserName,
					Password = request.Password,
					FkRol = 1,

				};

				_context.Usuarios.Add(usuario);
				int result = _context.SaveChanges();
				if (result > 0)
				{
					return true;
				}
				return false;

			}

			catch (Exception ex)
			{
				throw new Exception("Sucedio un error: " + ex.Message);
			}

		}

		public List<Usuario> ObtenerUsuario()
		{
			try
			{
				List<Usuario> result = _context.Usuarios.Include(x => x.Roles).ToList();

				return result;
			}

			catch (Exception ex)
			{
				throw new Exception("Sucedio un error: " + ex.Message);
			}
		}

		public Usuario GetUsuarioById(int id)
		{
			try
			{
				Usuario result = _context.Usuarios.Find(id);
				//Usuario result = _context.Usuarios.FirstOrDefault(x => x.PkUsuario == id);


				return result;
			}
			catch (Exception ex)
			{
				throw new Exception("Sucedio un error: " + ex.Message);
			}
		}

		public bool EliminarUsuario(int id)
		{
            try
            {
				var usuario = _context.Usuarios.Find(id);
				if (usuario != null)
				{
					_context.Usuarios.Remove(usuario);
					int result = _context.SaveChanges();
					if (result > 0)
					{
						return true;
					}
				}
				return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error al eliminar el usuario: " + ex.Message);
            }
        }

		public async Task<bool> EditarUsuario(Usuario request)
		{
            try
            {
				var usuario = await _context.Usuarios.FindAsync(request.PkUsuario);
                if (usuario == null) return false;
				usuario.Nombre = request.Nombre;
				usuario.UserName = request.UserName;
				usuario.Password = request.Password;

				_context.Usuarios.Update(usuario);
				int result = await _context.SaveChangesAsync();
				return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error al eliminar el usuario: " + ex.Message);
            }
        }




    }
}

