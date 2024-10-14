using Microsoft.EntityFrameworkCore;
using VIARO.API.Data;
using VIARO.API.Models.Entities;

namespace VIARO.API.Services
{
    public class AlumnoService
    {
        private readonly ApiContext _context;

        public AlumnoService(ApiContext context)
        {
            _context = context;
        }

        public async Task<List<Alumno>> GetAlumnos()
        {
            return await _context.Alumnos.ToListAsync();
        }
    }
}
