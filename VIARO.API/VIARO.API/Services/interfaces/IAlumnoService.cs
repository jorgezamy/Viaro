using Microsoft.AspNetCore.Mvc;
using VIARO.API.Models.Entities;

namespace VIARO.API.Services.interfaces
{
    public interface IAlumnoService
    {
        Task<List<Alumno>> GetAlumnos();

        Task<Alumno> CreateAlumno(Alumno newAlumno);

        Task<bool> UpdateAlumnoAsync(Guid id, Alumno alumno);

        Task<bool> DeleteAlumno(Guid id);
    }
}
