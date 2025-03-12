using System;
using Biblioteca_Josias_83.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca_Josias_83.Services.IServices
{
	public interface IUsuarioServices
	{
        public List<Usuario> ObtenerUsuario();

        public bool CrearUsuario(Usuario request);

        public Usuario GetUsuarioById(int id);

        public bool EliminarUsuario(int id);

        public Task<bool> EditarUsuario(Usuario request);



    }
}

