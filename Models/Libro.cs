using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibreriaAPI.Models
{
    public class Libro
    {
        [Key]
        public int libro_id { get; set; }
        public string titulo { get; set; } = string.Empty;
        public int autor_id { get; set; }
        public int año_publicacion { get; set; }
        public string genero { get; set; } = string.Empty;

        [JsonIgnore]
        public Autor? Autor { get; set; }
        [JsonIgnore]
        public List<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
    }
}