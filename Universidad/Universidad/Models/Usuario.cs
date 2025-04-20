using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Universidad.Models
{
    public class Usuario : IdentityUser
    {

        [ForeignKey("Persona")]
        public int PersonaId { get; set; }

        [Required]
        public string Rol { get; set; } = string.Empty;
        public Persona Persona { get; set; } = null!;
    }
}
