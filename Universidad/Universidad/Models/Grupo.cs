using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Universidad.Models
{
    public class Grupo
    {
        public int Id { get; set; }

        [Required]
        public string Horario { get; set; } = string.Empty;

        [Required]
        public int MateriaId { get; set; }

        [ValidateNever]
        public Materia Materia { get; set; } = null!;
    }
}