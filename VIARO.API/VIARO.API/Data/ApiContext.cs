using Microsoft.EntityFrameworkCore;
using VIARO.API.Models.Entities;

namespace VIARO.API.Data
{
    public class ApiContext: DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Profesor> profesores { get; set; }
    }
}
