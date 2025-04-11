using System.ComponentModel.DataAnnotations.Schema;

namespace Universidad.Models
{
    public class Matricula
    {
        public int Id { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        [ForeignKey("Grupo")]
        public int GrupoId { get; set; }

        public DateTime FechaMatricula { get; set; }

        public Usuario Usuario { get; set; }
        public Grupo Grupo { get; set; }
    }
}