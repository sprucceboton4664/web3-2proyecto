using _1._1.Models;
using System.ComponentModel.DataAnnotations;

namespace WAMVC.Models
{
    public class DetallePedidoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Si o si necesito un idPedido")]
        public int IdPedido { get; set; }

        [Required(ErrorMessage = "Si o si necesito un IdProducto")]
        public int IdProducto { get; set; }

        [Required(ErrorMessage = "Tiene que haber por lo menos un producto.")]
        [Range(1, 1000, ErrorMessage = "La cantidad debe ser entre 1 y 1000.")]
        public int Cantidad { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal PrecioUnitario { get; set; }

        public PedidoModel Pedido { get; set; }
        public ProductoModel Producto { get; set;
        public ProductoModel Productos { get; set; }
    }
}