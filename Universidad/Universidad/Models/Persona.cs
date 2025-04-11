using System.ComponentModel.DataAnnotations;

namespace Universidad.Models
{
    public class Persona
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        [StringLength(20)]
        public string Telefono { get; set; }

        [Required]
        public string Tipo { get; set; } // Estudiante o Administrador
    }
}