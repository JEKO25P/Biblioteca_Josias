using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca_Josias_83.Models.Domain
{
    public class LibrosCategorias
    {
        [Key]
        public int PkLibrosCategorias { get; set; }
        [ForeignKey("Libros")]
        public int FkLibro { get; set; }
        public Libro Libros { get; set; }
        [ForeignKey("Categorias")]
        public int FkCategoria { get; set; }
        public Categoria Categorias { get; set; }
    }
}

