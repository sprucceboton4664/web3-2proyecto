using Microsoft.EntityFrameworkCore;
using pedido1.Models;

namespace pedido1.Data
{

    public class PedidosDBContext : DbContext
    {
        public PedidosDBContext() { }
        public PedidosDBContext(DbContextOptions<PedidosDBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Precio)
                .HasColumnType("decimal(8,2)");

            modelBuilder.Entity<Order>()
                .Property(o => o.Total)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.Subtotal)
                .HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Cliente)
                .WithMany(u => u.Pedidos)
                .HasForeignKey(o => o.IdCliente);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Pedido)
                .WithMany(o => o.DetallePedidos)
                .HasForeignKey(oi => oi.IdPedido);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Producto)
                .WithMany(p => p.DetallePedidos)
                .HasForeignKey(oi => oi.IdProducto);
        }

    }

}
 