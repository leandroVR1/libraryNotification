using System.Text.Json.Serialization;
namespace LuegoPago.Models
{
   public class TipoDocumento
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }

        // [JsonIgnore]
        // public virtual ICollection<Usuario>? Usuarios { get; set; }
    }
}