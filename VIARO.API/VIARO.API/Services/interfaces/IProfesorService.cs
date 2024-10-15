using VIARO.API.Models.Entities;

namespace VIARO.API.Services.interfaces
{
    public interface IProfesorService
    {
        Task<List<Alumno>> GetProfesores();

        Task<Alumno> CreateProfesor(Alumno newAlumno);

        Task<bool> UpdateProfesorAsync(Guid id, Alumno alumno);

        Task<bool> DeleteProfesor(int id);
    }
}
