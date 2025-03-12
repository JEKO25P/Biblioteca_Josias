using System;
namespace Biblioteca_Josias_83.Services.IServices
{
    public interface ILoginServices
    {
        string Authenticate(string username, string password);
    }
}

