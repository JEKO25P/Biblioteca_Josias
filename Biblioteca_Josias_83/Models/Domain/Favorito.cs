using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca_Josias_83.Models.Domain
{
    public class Favorito
    {
        [Key]

        public int PKFavorito { get; set; }

        [ForeignKey("Usuarios")]
        public int FkUsuario { get; set; }  // Cambiar a string
        public Usuario Usuario { get; set; }
        [ForeignKey("Libros")]
        public int FkLibro { get; set; }
        public Libro Libros { get; set; }

    }
}

