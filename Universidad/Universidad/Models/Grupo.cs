using System.ComponentModel.DataAnnotations;

namespace Universidad.Models
{
    public class Grupo
    {
        [Key]
        public int Id_Grupo { get; set; }

        [Required, StringLength(50)]
        public string Nombre_Grupo { get; set; }

        [Required]
        public int Id_Educador { get; set; }

        public Educador Educador { get; set; }
        public ICollection<Estudiante> Estudiantes { get; set; }
    }
}
