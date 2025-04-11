using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Universidad.Models
{
    public class EscuelaDbContext : DbContext
    {
        public EscuelaDbContext(DbContextOptions<EscuelaDbContext> options) : base(options) { }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Educador> Educadores { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<EducadorXMateria> EducadorXMaterias { get; set; }
        public DbSet<Nota> Notas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EducadorXMateria>()
                .HasKey(em => new { em.Id_Educador, em.Id_Materia });

            modelBuilder.Entity<EducadorXMateria>()
                .HasOne(em => em.Educador)
                .WithMany(e => e.EducadorXMaterias)
                .HasForeignKey(em => em.Id_Educador);

            modelBuilder.Entity<EducadorXMateria>()
                .HasOne(em => em.Materia)
                .WithMany(m => m.EducadorXMaterias)
                .HasForeignKey(em => em.Id_Materia);
        }
    }
}