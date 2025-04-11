using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Universidad.Models
{
    public class Educador
    {
        [Key]
        public int Id_Educador { get; set; }

        [Required]
        public int Id_Persona { get; set; }

        [StringLength(100)]
        public string? Especialidad { get; set; }

        public Persona Persona { get; set; }
        public ICollection<Grupo> Grupos { get; set; }
        public ICollection<EducadorXMateria> EducadorXMaterias { get; set; }
    }
}