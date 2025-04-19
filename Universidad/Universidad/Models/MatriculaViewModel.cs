using System.ComponentModel.DataAnnotations;

namespace Universidad.Models
{
    public class MatriculaViewModel
    {
        [Required]
        public int CarreraId { get; set; }

        [Required]
        public int MateriaId { get; set; }

        [Required]
        public int GrupoId { get; set; }

        public List<Carrera> Carreras { get; set; } = new();
        public List<Materia> Materias { get; set; } = new();
        public List<Grupo> Grupos { get; set; } = new();
    }

}
