using System.Text.Json.Serialization;

namespace LuegoPago.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Documento { get; set; }
        public int? IdTipoDocumento { get; set; }
        public int? IdRol { get; set; }
        // public virtual TipoDocumento TipoDocumento { get; set; }
        // public virtual Rol Rol { get; set; }

        // [JsonIgnore]
        // public virtual ICollection<Cupon> Cupones { get; set; }

        // [JsonIgnore]
        // public virtual ICollection<HistorialRedimido> HistorialRedimidos { get; set; }
    }
}