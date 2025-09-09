namespace _1._1.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int IdPedido {  get; set; }
        public int IdProducto {  get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
