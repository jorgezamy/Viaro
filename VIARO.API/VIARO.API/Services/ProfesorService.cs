using Microsoft.EntityFrameworkCore;
using VIARO.API.Data;
using VIARO.API.Models.Entities;
using VIARO.API.Services.interfaces;

namespace VIARO.API.Services
{
    public class ProfesorService : IProfesorService
    {
        private readonly ApiContext _context;

        public ProfesorService(ApiContext context)
        {
            _context = context;
        }

        public async Task<List<Profesor>> GetProfesores()
        {
            return await _context.Profesores.ToListAsync();
        }

        public async Task<Profesor> CreateProfesor(Profesor newProfesor)
        {
            _context.Profesores.Add(newProfesor);
            await _context.SaveChangesAsync();

            return newProfesor;
        }

        public async Task<bool> UpdateProfesorAsync(Guid id, Profesor updatedProfesor)
        {
            var Profesor = await _context.Profesores.FindAsync(id);

            if (Profesor == null) return false;

            _context.Entry(Profesor).CurrentValues.SetValues(updatedProfesor);
            _context.Entry(Profesor).Property(c => c.Id).IsModified = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Profesores.Any(c => c.Id == id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public async Task<bool> DeleteProfesor(Guid id)
        {
            var profesor = await _context.Profesores.FindAsync(id);

            if (profesor == null)
            {
                return false;
            }

            _context.Profesores.Remove(profesor);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
