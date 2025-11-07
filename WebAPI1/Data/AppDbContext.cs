using WebAPI1.models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI1.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet <User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
