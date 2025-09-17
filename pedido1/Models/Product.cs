using System.Collections.Generic;

namespace pedido1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public ICollection<OrderItem> DetallePedidos { get; set; }
    }
}