using VIARO.API.Models.DTOs;
using VIARO.API.Models.Entities;

namespace VIARO.API.Services.interfaces
{
    public interface IGradosAlumnosService
    {
        Task<List<GradoDTO>> GetGradosAsync();
        Task<GradoDTO> CreateGradoAsync(GradoDTO grado);
        Task<bool> UpdateGradoAsync(int id, GradoDTO updatedGrado);
        Task<bool> DeleteGradoAsync(int id);

        Task<List<AlumnoGrado>> GetAlumnoGradosAsync();
        Task<AlumnoGrado> CreateAlumnoGradoAsync(AlumnoGrado alumnoGrado);
        Task<bool> UpdateAlumnoGradoAsync(int id, AlumnoGrado updatedGrado);
        Task<bool> DeleteAlumnoGradoAsync(int id);
    }
}
