using System.ComponentModel.DataAnnotations;

namespace Biblioteca_Josias_83.Models.Domain
{
    public class Autor
    {
        [Key]
        public int PkAutor { get; set; }
        public string Nombre { get; set; }
        public byte[] Foto { get; set; }
        public string Descripcion { get; set; }
    }
}

