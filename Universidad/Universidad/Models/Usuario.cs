using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Universidad.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [ForeignKey("Persona")]
        public int PersonaId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Rol { get; set; } // Estudiante o Administrador

        public Persona Persona { get; set; }
    }
}
