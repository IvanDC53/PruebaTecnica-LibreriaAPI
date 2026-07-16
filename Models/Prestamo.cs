using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LibreriaAPI.Models
{
    public class Prestamo
    {
        [Key]
        public int prestamo_id { get; set; }

        public int libro_id { get; set; }

        public DateTime fecha_prestamo { get; set; }

        public DateTime? fecha_devolucion { get; set; }

        [ForeignKey("libro_id")]
        [JsonIgnore]
        public Libro? Libro { get; set; }
    }
}