using VIARO.API.Models.Entities;

namespace VIARO.API.Services.interfaces
{
    public interface IProfesorService
    {
        Task<List<Profesor>> GetProfesores();

        Task<Profesor> CreateProfesor(Profesor newProfesor);

        Task<bool> UpdateProfesorAsync(Guid id, Profesor profesor);

        Task<bool> DeleteProfesor(Guid id);
    }
}
