using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Universidad.Models
{
    public class Materia
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        public List<MateriaCarrera> MateriasCarreras { get; set; } = new();

        public List<Grupo> Grupos { get; set; } = new();
    }
}