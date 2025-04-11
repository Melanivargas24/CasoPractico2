using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Universidad.Models
{
    public class UniversidadDbContext : IdentityDbContext
    {
        public UniversidadDbContext(DbContextOptions<UniversidadDbContext> options)
            : base(options)
        {
        }

        // Agregar los DbSet por cada Modelo
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Necesario para Identity

            // Configuración personalizada de relaciones si es necesario
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Persona)
                .WithMany()
                .HasForeignKey(u => u.PersonaId);

            modelBuilder.Entity<Materia>()
                .HasOne(m => m.Carrera)
                .WithMany()
                .HasForeignKey(m => m.CarreraId);

            modelBuilder.Entity<Grupo>()
                .HasOne(g => g.Materia)
                .WithMany()
                .HasForeignKey(g => g.MateriaId);

            modelBuilder.Entity<Matricula>()
                .HasOne(m => m.Usuario)
                .WithMany()
                .HasForeignKey(m => m.UsuarioId);

            modelBuilder.Entity<Matricula>()
                .HasOne(m => m.Grupo)
                .WithMany()
                .HasForeignKey(m => m.GrupoId);
        }
    }
}
