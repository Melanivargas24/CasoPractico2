using System.ComponentModel.DataAnnotations.Schema;

namespace Universidad.Models
{
    public class MateriaCarrera
    {
        public int MateriaId { get; set; }
        public Materia Materia { get; set; } = null!;

        public int CarreraId { get; set; }
        public Carrera Carrera { get; set; } = null!;
    }
}