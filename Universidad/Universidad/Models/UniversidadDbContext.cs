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

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<MateriaCarrera> MateriasCarreras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Persona)
                .WithMany()
                .HasForeignKey(u => u.PersonaId);

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

            modelBuilder.Entity<MateriaCarrera>()
                .HasKey(mc => new { mc.MateriaId, mc.CarreraId });

            modelBuilder.Entity<MateriaCarrera>()
                .HasOne(mc => mc.Materia)
                .WithMany(m => m.MateriasCarreras)
                .HasForeignKey(mc => mc.MateriaId);

            modelBuilder.Entity<MateriaCarrera>()
                .HasOne(mc => mc.Carrera)
                .WithMany(c => c.MateriasCarreras)
                .HasForeignKey(mc => mc.CarreraId);
        }
    }
}