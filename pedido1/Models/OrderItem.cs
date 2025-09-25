namespace pedido1.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public Order Pedido { get; set; }
        public Product Producto { get; set; }
    }
}