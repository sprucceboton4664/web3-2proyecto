using System.ComponentModel.DataAnnotations;

namespace PrimerParcial.Models
{
    public class Ingredient
    {
        //Completar el proyecto implementando los modelos faltantes , soluciones simples apegarse al mvc utilizando principios SOLID DRY y KISS , buenas practicas escalable terminar  implementando  las vistas y controladores de manera  correcta 
        // hacer validaciones unicamente necesarias implementar las vistas en el layout sin problemas y Mantenlo simple

        // Clave Primaria (PK)
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } // Ejemplo: "Harina de Trigo"

        [Required]
        public string Quantity { get; set; } // Ejemplo: "2 tazas" o "500 gramos"

        // --- Relaciones de Entity Framework Core ---

        // Clave Foránea (FK): Vincula este ingrediente a la receta
        public int RecipeId { get; set; }

        // Propiedad de Navegación: El lado 'uno'
        public Recipe Recipe { get; set; }
    }
}
