using System.ComponentModel.DataAnnotations;

namespace Universidad.Models
{
    public class Materia
    {
        [Key]
        public int Id_Materia { get; set; }

        [Required, StringLength(100)]
        public string Nombre_Materia { get; set; }

        public ICollection<EducadorXMateria> EducadorXMaterias { get; set; }
    }
}