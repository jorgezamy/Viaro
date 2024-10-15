using Microsoft.EntityFrameworkCore;
using VIARO.API.Models.Entities;

namespace VIARO.API.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<AlumnoGrado> AlumnoGrados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlumnoGrado>()
                .HasOne(g => g.Alumno)
                .WithMany()
                .HasForeignKey(g => g.AlumnoId);

            modelBuilder.Entity<AlumnoGrado>()
                .HasOne(g => g.Grado)
                .WithMany()
                .HasForeignKey(ag => ag.GradoId);

            modelBuilder.Entity<Grado>()
                .HasOne(g => g.Profesor)
                .WithMany(p => p.Grados)
                .HasForeignKey(g => g.ProfesorId);
        }
    }
}
