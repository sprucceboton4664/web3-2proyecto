using System.ComponentModel.DataAnnotations;

namespace PrimerParcial.Models
{
    public class Category
    {
        // Clave Primaria (PK)
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } // Ejemplo: "Postres", "Platos Principales"

        public string Description { get; set; }

        // --- Relaciones de Entity Framework Core ---

        // Propiedad de Navegación: El lado 'muchos' para las Recetas en esta Categoría
        public ICollection<Recipe> Recipes { get; set; }
    }
}
