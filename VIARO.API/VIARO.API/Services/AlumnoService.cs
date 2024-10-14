using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VIARO.API.Data;
using VIARO.API.Models.Entities;
using VIARO.API.Services.interfaces;

namespace VIARO.API.Services
{
    public class AlumnoService: IAlumnoService
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

        public async Task<Alumno> CreateAlumno(Alumno newAlumno)
        {
            _context.Alumnos.Add(newAlumno);
            await _context.SaveChangesAsync();

            return newAlumno;
        }

        public async Task<bool> UpdateAlumnoAsync(Guid id, Alumno updatedAlumno)
        {
            var alumno = await _context.Alumnos.FindAsync(id);

            if (alumno == null) return false;

            _context.Entry(alumno).CurrentValues.SetValues(updatedAlumno);
            _context.Entry(alumno).Property(c => c.Id).IsModified = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Alumnos.Any(c => c.Id == id))
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

        public async Task<bool> DeleteAlumno(int id)
        {
            var alumno = await _context.Alumnos.FindAsync(id);

            if (alumno != null)
            {
                return false;
            }

            _context.Alumnos.Remove(alumno);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
