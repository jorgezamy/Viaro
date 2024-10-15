using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using VIARO.API.Data;
using VIARO.API.Models.Entities;
using VIARO.API.Services.interfaces;

namespace VIARO.API.Services
{
    public class GradosAlumnosService: IGradosAlumnosService
    {
        private readonly ApiContext _context;

        public GradosAlumnosService(ApiContext context)
        {
            _context = context;
        }

        public async Task<List<Grado>> GetGradosAsync()
        {
            return await _context.Grados.ToListAsync();
        }

        public async Task<Grado> CreateGradoAsync(Grado grado)
        {
            _context.Grados.Add(grado);
            await _context.SaveChangesAsync();

            return grado;
        }

        public async Task<bool> UpdateGradoAsync(int id, Grado updatedGrado)
        {
            var grado = await _context.Grados.FindAsync(id);

            if(grado == null) return false;

            _context.Entry(grado).CurrentValues.SetValues(updatedGrado);
            _context.Entry(grado).Property(c => c.Id).IsModified = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Grados.Any(c => c.Id == id)) return false;
                else throw;
            }

            return true;
        }

        public async Task<bool> DeleteGradoAsync(int id)
        {
            var grado = await _context.Grados.FindAsync(id);

            if(grado == null) return false;

            _context.Grados.Remove(grado);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<AlumnoGrado>> GetAlumnoGradosAsync()
        {
            return await _context.AlumnoGrados.ToListAsync();
        }

        public async Task<AlumnoGrado> CreateAlumnoGradoAsync(AlumnoGrado alummnoGrado)
        {
            _context.AlumnoGrados.Add(alummnoGrado);
            await _context.SaveChangesAsync();

            return alummnoGrado;
        }

        public async Task<bool> UpdateAlumnoGradoAsync(int id, AlumnoGrado updatedAlumnoGrado)
        {
            var alumnoGrado = await _context.AlumnoGrados.FindAsync(id);

            if (alumnoGrado == null) return false;

            _context.Entry(alumnoGrado).CurrentValues.SetValues(updatedAlumnoGrado);
            _context.Entry(alumnoGrado).Property(c => c.Id).IsModified = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.AlumnoGrados.Any(c => c.Id == id)) return false;
                else throw;
            }

            return true;
        }

        public async Task<bool> DeleteAlumnoGradoAsync(int id)
        {
            var alumnoGrado = await _context.AlumnoGrados.FindAsync(id);

            if (alumnoGrado == null) return false;

            _context.AlumnoGrados.Remove(alumnoGrado);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
