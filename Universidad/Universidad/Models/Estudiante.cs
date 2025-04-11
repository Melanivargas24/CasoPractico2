using System.ComponentModel.DataAnnotations;

namespace Universidad.Models
{
    public class Estudiante
    {
        [Key]
        public int Id_Estudiante { get; set; }

        [Required]
        public int Id_Persona { get; set; }

        public int? Id_Grupo { get; set; }

        public Persona Persona { get; set; }
        public Grupo? Grupo { get; set; }
        public ICollection<Nota> Notas { get; set; }
    }
}
