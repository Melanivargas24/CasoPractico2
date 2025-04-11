using System.ComponentModel.DataAnnotations;

namespace Universidad.Models
{
    public class Nota
    {
        [Key]
        public int Id_Nota { get; set; }

        [Required]
        public int Id_Estudiante { get; set; }

        [Required]
        public int Id_Materia { get; set; }

        [Required]
        public decimal Calificacion { get; set; }

        public Estudiante Estudiante { get; set; }
        public Materia Materia { get; set; }
    }
}