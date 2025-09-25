using System.ComponentModel.DataAnnotations;

namespace PrimerParcial.Models
{
    public class Recipe
    {

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } 

        [Required]
        public string Description { get; set; } 

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El tiempo de preparación debe ser mayor a 0")]
        public int PreparationTimeMinutes { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Las porciones deben ser mayor a 0")]
        public int Servings { get; set; }

        [Required]
        public string Instructions { get; set; } 

        public DateTime DateCreated { get; set; } = DateTime.Now;

        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}