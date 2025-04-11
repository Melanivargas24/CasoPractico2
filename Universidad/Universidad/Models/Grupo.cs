using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Universidad.Models
{
    public class Grupo
    {
        public int Id { get; set; }

        [ForeignKey("Materia")]
        public int MateriaId { get; set; }

        [Required]
        public string Horario { get; set; }

        public Materia Materia { get; set; }
    }
}