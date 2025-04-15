using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Universidad.Models
{
    public class Carrera
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        public List<MateriaCarrera> MateriasCarreras { get; set; } = new();
    }
}