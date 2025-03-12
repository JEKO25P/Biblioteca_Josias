using System.ComponentModel.DataAnnotations;

namespace Biblioteca_Josias_83.Models.Domain
{
    public class Categoria
    {
        [Key]
        public int PkCategoria { get; set; }

        [Required]
        public string Nombre { get; set; }
        public ICollection<LibrosCategorias> LibrosCategorias { get; set; }
    }
}

