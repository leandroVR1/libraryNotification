namespace LuegoPago.Models
{
    public class RangoPrecio
    {
        public int Id { get; set; }
        public double Minimo { get; set; }
        public double Maximo { get; set; }

        // public virtual ICollection<Cupon> Cupones { get; set; }
    }

}