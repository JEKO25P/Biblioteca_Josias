using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Biblioteca_Josias_83.Models.Domain;

namespace Biblioteca_Josias_83.Models
{
    public class Libro
    {
        [Key]
        public int PkLibro { get; set; }

        [Required]
        public string Titulo { get; set; }

        public string Descripcion { get; set; }
        public byte[] Imagen { get; set; }  // Ahora es un array de bytes
        public int AñoPublicacion { get; set; }
        public string Editorial { get; set; }
        public string UrlLectura { get; set; } // Para redirigir a la lectura

        [ForeignKey("Categorias")]
        public int FkCategoria { get; set; }
        public Categoria Categorias { get; set; }

        [ForeignKey("Autores")]
        public int FkAutor { get; set; }
        public Autor Autores { get; set; }
        public ICollection<LibrosCategorias> LibrosCategorias { get; set; }

    }
}
