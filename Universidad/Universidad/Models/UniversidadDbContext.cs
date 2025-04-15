using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Universidad.Models
{
    public class UniversidadDBContext : IdentityDbContext
    {
        public UniversidadDBContext(DbContextOptions<UniversidadDBContext> options)
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
                .WithMany(c => c.Materias)
                .HasForeignKey(m => m.CarreraId);

            modelBuilder.Entity<Grupo>()
                .HasOne(g => g.Materia)
                .WithMany(m => m.Grupos)
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
