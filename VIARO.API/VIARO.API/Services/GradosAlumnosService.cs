using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using VIARO.API.Data;
using VIARO.API.Models.DTOs;
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

        private Grado MapToGrado(GradoDTO gradoDTO)
        {
            var grado = new Grado
            {
                Nombre = gradoDTO.Nombre,
                ProfesorId = gradoDTO.ProfesorId,
            };

            if (gradoDTO.Id.HasValue)
            {
                grado.Id = gradoDTO.Id.Value;
            }

            return grado;
        }

        private AlumnoGrado MapToAlumnoGrado(AlumnoGradoDTO alumnoGradoDTO)
        {
            var alumnoGrado = new AlumnoGrado
            {
                AlumnoId = alumnoGradoDTO.AlumnoId,
                GradoId= alumnoGradoDTO.GradoId,
                Seccion= alumnoGradoDTO.Seccion
            };

            if (alumnoGradoDTO.Id.HasValue)
            {
                alumnoGrado.Id = alumnoGradoDTO.Id.Value;
            }

            return alumnoGrado;
        }

        public async Task<List<GradoDTO>> GetGradosAsync()
        {
            var grados = await _context.Grados.ToListAsync();

            var gradosDTOs = grados.Select(grado => new GradoDTO
            {
                Id = grado.Id,
                Nombre = grado.Nombre,
                ProfesorId = grado.ProfesorId
            }).ToList();

            return gradosDTOs;
        }

        public async Task<GradoDTO> CreateGradoAsync(GradoDTO gradoDTO)
        {
            var grado = MapToGrado(gradoDTO);

            _context.Grados.Add(grado);
            await _context.SaveChangesAsync();

            gradoDTO.Id = grado.Id;

            return gradoDTO;
        }

        public async Task<bool> UpdateGradoAsync(int id, GradoDTO updatedGrado)
        {
            var grado = await _context.Grados.FindAsync(id);

            if(grado == null) return false;

            var updatedEntity = MapToGrado(updatedGrado);

            _context.Entry(grado).CurrentValues.SetValues(updatedEntity);
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

        public async Task<List<AlumnoGradoDTO>> GetAlumnoGradosAsync()
        {
            var alumnosGrados = await _context.AlumnoGrados.ToListAsync();

            var alumnosGradosDTO = alumnosGrados.Select(alumnoGrado => new AlumnoGradoDTO
            {
                Id = alumnoGrado.Id,
                AlumnoId = alumnoGrado.AlumnoId,
                GradoId = alumnoGrado.GradoId,
                Seccion = alumnoGrado.Seccion,
            }).ToList();

            return alumnosGradosDTO;
        }

        public async Task<AlumnoGradoDTO> CreateAlumnoGradoAsync(AlumnoGradoDTO alumnoGradoDTO)
        {
            var alumnoGrado = MapToAlumnoGrado(alumnoGradoDTO);

            _context.AlumnoGrados.Add(alumnoGrado);
            await _context.SaveChangesAsync();

            alumnoGradoDTO.Id = alumnoGrado.Id;

            return alumnoGradoDTO;
        }

        public async Task<bool> UpdateAlumnoGradoAsync(int id, AlumnoGradoDTO updatedAlumnoGrado)
        {
            var alumnoGrado = await _context.AlumnoGrados.FindAsync(id);

            if (alumnoGrado == null) return false;

            var newEntity = MapToAlumnoGrado(updatedAlumnoGrado);

            _context.Entry(alumnoGrado).CurrentValues.SetValues(newEntity);
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
