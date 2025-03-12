using System;
using Biblioteca_Josias_83.Models;

namespace Biblioteca_Josias_83.Services.IServices
{
    public interface IUserServices
    {
        public List<Usuario> GetUsuarios();
        public bool CreateUser(Usuario request);
        public Usuario GetUser(int id);
        public bool UpdateUser(Usuario request);
        public bool DeleteUser(int id);
    }
}

