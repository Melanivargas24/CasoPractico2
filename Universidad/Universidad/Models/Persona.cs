using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Universidad.Models
{
    public class Persona
    {
        [Key]
        public int Id_Persona { get; set; }

        [Required, StringLength(100)]
        public string Nombre { get; set; }

        [Required, StringLength(100)]
        public string Apellido { get; set; }

        [Required]
        public DateTime Fecha_Nacimiento { get; set; }

        [StringLength(255)]
        public string? Direccion { get; set; }

        [StringLength(15)]
        public string? Telefono { get; set; }

        [Required]
        [Column(TypeName = "char(1)")]
        public char Estado { get; set; } = 'A';

    }
}
