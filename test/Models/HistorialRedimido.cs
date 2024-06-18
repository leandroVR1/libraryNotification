namespace LuegoPago.Models
{
    public class HistorialRedimido
    {
        public int Id { get; set; }
        public int? IdCupon { get; set; }
        public int? IdUsuario { get; set; }

        // public virtual Cupon? Cupon { get; set; }
        // public virtual Usuario? Usuario { get; set; }
    }

}