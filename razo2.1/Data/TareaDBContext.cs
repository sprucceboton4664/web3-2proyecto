using Microsoft.EntityFrameworkCore;
using razo2._1.Models;
namespace razo2._1.Data
{
    public class TareaDBContex : DbContext
    {
        public TareaDBContex(DbContextOptions<TareaDBContex> options) : base(options)
        {
            
        }
        public DbSet<Tarea> Tareas { get; set; } 1
        protected TareaDBContex()
        {

        }
    }
}
