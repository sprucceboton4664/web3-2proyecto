using System.ComponentModel.DataAnnotations;

namespace _1._1.Models
{
    public class ProductoModel
    {
        //public int Id {get; set;}
        public int Id { get; set; }
        [Key]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Precion  { get; set; }

        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
