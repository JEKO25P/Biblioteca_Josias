using Microsoft.EntityFrameworkCore;
using Biblioteca_Josias_83.Models;
namespace Biblioteca_Josias_83.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        //modelos a mapear
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Libro> Libros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Rol>().HasData(
                new Rol { PkRol = 1, Nombre = "Admin" }, // Rol de administrador
                new Rol { PkRol = 2, Nombre = "Usuario" } // Rol de usuario regular
            );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    PkUsuario = 1,
                    Nombre = "Jonny",
                    UserName = "admin",
                    Password = "123",
                    FkRol = 1 // Asignar rol de administrador
                },
                new Usuario
                {
                    PkUsuario = 2,
                    Nombre = "Usuario",
                    UserName = "user",
                    Password = "123",
                    FkRol = 2 // Asignar rol de usuario regular
                }
            );
        }

    }
}