using Microsoft.EntityFrameworkCore;
using Biblioteca_Josias_83.Models;
using Biblioteca_Josias_83.Models.Domain;

namespace Biblioteca_Josias_83.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Favorito> Favoritos { get; set; }
        public DbSet<LibrosCategorias> LibrosCategorias { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la tabla LibrosCategorias
            modelBuilder.Entity<LibrosCategorias>()
                .HasKey(lc => lc.PkLibrosCategorias);

            modelBuilder.Entity<LibrosCategorias>()
                .HasOne(lc => lc.Libros)
                .WithMany(l => l.LibrosCategorias)
                .HasForeignKey(lc => lc.FkLibro)
                .OnDelete(DeleteBehavior.NoAction); // Evitar cascada

            modelBuilder.Entity<LibrosCategorias>()
                .HasOne(lc => lc.Categorias)
                .WithMany(c => c.LibrosCategorias)
                .HasForeignKey(lc => lc.FkCategoria)
                .OnDelete(DeleteBehavior.NoAction); // Evitar cascada
        }

    }
}