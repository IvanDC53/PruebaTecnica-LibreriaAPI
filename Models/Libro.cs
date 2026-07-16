using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LibreriaAPI.Models
{
    public class Libro
    {
        [Key]
        public int libro_id { get; set; }

        public string titulo { get; set; } = string.Empty;

        public int año_publicacion { get; set; }

        public int autor_id { get; set; }

        [ForeignKey("autor_id")]
        [JsonIgnore]
        public Autor? Autor { get; set; }

        [JsonIgnore]
        public ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
    }
}