namespace LuegoPago.Models
{
    public class RegistroFecha
    {
        public int Id { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActivacion { get; set; }
        public DateTime? FechaExpiracion { get; set; }

        // public virtual ICollection<Cupon>? Cupones { get; set; }
    }

}