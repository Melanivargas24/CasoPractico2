using System.ComponentModel.DataAnnotations;

namespace Universidad.Models
{
    public class Grupo
    {
        public int Id { get; set; }

        [Required]
        public string Horario { get; set; } = string.Empty;

        public int MateriaId { get; set; }
        public Materia Materia { get; set; } = null!;
    }
}