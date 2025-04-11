using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Universidad.Models
{
    public class Materia
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [ForeignKey("Carrera")]
        public int CarreraId { get; set; }

        public Carrera Carrera { get; set; }
    }
}