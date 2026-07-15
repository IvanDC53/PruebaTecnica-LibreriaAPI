using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibreriaAPI.Models
{
    public class Autor
    {
        [Key]
        public int autor_id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string nacionalidad { get; set; } = string.Empty;

        [JsonIgnore]
        public List<Libro> Libros { get; set; } = new List<Libro>();
    }
}