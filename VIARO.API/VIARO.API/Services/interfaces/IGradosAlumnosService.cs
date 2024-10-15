using VIARO.API.Models.Entities;

namespace VIARO.API.Services.interfaces
{
    public interface IGradosAlumnosService
    {
        Task<List<Grado>> GetGradosAsync();
        Task<Grado> CreateGradoAsync(Grado grado);
        Task<bool> UpdateGradoAsync(int id, Grado updatedGrado);
        Task<bool> DeleteGradoAsync(int id);

        Task<List<AlumnoGrado>> GetAlumnoGradosAsync();
        Task<AlumnoGrado> CreateAlumnoGradoAsync(AlumnoGrado alumnoGrado);
        Task<bool> UpdateAlumnoGradoAsync(int id, AlumnoGrado updatedGrado);
        Task<bool> DeleteAlumnoGradoAsync(int id);
    }
}
