using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Universidad.Models
{
    public class Matricula
    {
        public int Id { get; set; }

        [ForeignKey("Usuario")]
        public string UsuarioId { get; set; } = string.Empty;

        [ForeignKey("Grupo")]
        public int GrupoId { get; set; }

        public DateTime FechaMatricula { get; set; }

        public Usuario Usuario { get; set; } = null!;
        public Grupo Grupo { get; set; }
    }
}