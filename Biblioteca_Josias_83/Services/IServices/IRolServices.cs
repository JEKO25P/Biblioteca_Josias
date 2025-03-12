using System;
using Biblioteca_Josias_83.Models;

namespace Biblioteca_Josias_83.Services.IServices
{
    public interface IRolServices
    {
        List<Rol> GetRoles();
        public bool CreateRol(Rol request);
        public Rol GetRol(int id);
        public bool UpdateRol(Rol request);
        public bool DeleteRol(int id);
    }
}

