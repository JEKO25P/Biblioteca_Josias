using System.ComponentModel.DataAnnotations;

namespace Biblioteca_Josias_83.Models
{
    public class Rol
    {
        [Key]
        public int PkRol { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
    }
}