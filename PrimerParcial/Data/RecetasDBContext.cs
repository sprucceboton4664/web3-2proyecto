using Microsoft.EntityFrameworkCore;
using PrimerParcial.Models;

namespace PrimerParcial.Data
{
    public class RecetasDBContext : DbContext
    {
        // Constructor que acepta DbContextOptions para la configuración
        public RecetasDBContext(DbContextOptions<RecetasDBContext> options)
            : base(options)
        {
        }

        // DbSets (Colecciones) que mapean a las tablas de la base de datos

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Category> Categories { get; set; }

        // Opcional: Configuración de la relación uno a muchos
        // Esto a menudo se puede omitir si las convenciones de EF Core se cumplen,
        // pero es buena práctica para claridad, especialmente en relaciones complejas.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura la relación uno a muchos entre Recipe e Ingredient
            modelBuilder.Entity<Ingredient>()
                .HasOne(i => i.Recipe) // Un ingrediente tiene una receta
                .WithMany(r => r.Ingredients) // Una receta tiene muchos ingredientes
                .HasForeignKey(i => i.RecipeId); // Usa RecipeId como clave foránea

            // Configura la relación uno a muchos entre Category y Recipe
            modelBuilder.Entity<Recipe>()
                .HasOne(r => r.Category) // Una receta tiene una categoría
                .WithMany(c => c.Recipes) // Una categoría tiene muchas recetas
                .HasForeignKey(r => r.CategoryId); // Usa CategoryId como clave foránea

            base.OnModelCreating(modelBuilder);
        }
    }
}
