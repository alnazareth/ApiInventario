using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.Models
{
    public class Product
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del producto es requerido.")]
        [MinLength(1, ErrorMessage = "El nombre no puede ser una cadena vacía.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El tipo de preparación es requerido.")]
        [MinLength(1, ErrorMessage = "El tipo de preparación no puede ser una cadena vacía.")]
        public string PreparationType { get; set; } // (e.g., "Elaborado a mano", "Elaborado a mano y máquina")
       
        [Required(ErrorMessage = "El estado es requerido.")]
        [MinLength(1, ErrorMessage = "El estado no puede ser una cadena vacía.")]
        public string Status { get; set; }          // (e.g., "En stock", "Defectuoso", etc.)
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad de productos en stock no puede ser negativa.")]
        // Nuevo campo para manejar la cantidad de productos en stock
        public int InStock { get; set; } = 10;
    }
}
