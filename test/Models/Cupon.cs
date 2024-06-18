namespace LuegoPago.Models
{
    public class Cupon
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Descuento { get; set; }
        public int CantidadDisponible { get; set; }
        public int LimiteUsoUsuario { get; set; }
        public int? IdEmpleado { get; set; }
        public int? IdMarca { get; set; }
        public int? IdRegistroFechas { get; set; }
        public int? IdEstado { get; set; }
        public int? IdTipoDescuento { get; set; }
        public int? IdRangoPrecio { get; set; }

        // public virtual Usuario? Empleado { get; set; }
        // public virtual Marca? Marca { get; set; }
        // public virtual RegistroFecha? RegistroFechas { get; set; }
        // public virtual Estado? Estado { get; set; }
        // public virtual TipoDescuento? TipoDescuento { get; set; }
        // public virtual RangoPrecio? RangoPrecio { get; set; }
        // public virtual ICollection<HistorialRedimido>? HistorialRedimidos { get; set; }
    }


}
