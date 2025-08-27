namespace razo2._1.Models
{
    public class Tarea
    {
        public int IdTarea { get; set; }
        public string NombreTarea { get; set; }
        public DateTime FechaVencimiento { get; set; }    
        public string estado { get; set; }
        public int IdUsuario { get; set; }
    }
}
