using Microsoft.AspNetCore.Mvc;
using VIARO.API.Models.Entities;
using VIARO.API.Services.interfaces;

namespace VIARO.API.Controllers
{
    public class ProfesoresController : Controller
    {
        private readonly IProfesorService _profesorService;

        public ProfesoresController(IProfesorService profesorService)
        {
            _profesorService = profesorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Alumno>>> GetAlumnos()
        {
            var alumnos = await _profesorService.GetProfesores();

            if (alumnos == null || !alumnos.Any())
            {
                return NotFound();
            }

            return Ok(alumnos);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProfesor([FromBody] Profesor profesor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { status = "Error", result = ModelState });
            }

            var createdProfesor = await _profesorService.CreateProfesor(profesor);


            return CreatedAtAction(nameof(CreateProfesor), new { id = createdProfesor.Id }, new { status = "Ok", result = new { alumno = createdProfesor } });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProfesor(Guid id, [FromBody] Profesor updatedProfesor)
        {
            if (id != updatedProfesor.Id) return BadRequest(new { status = "Error", result = "El ID del alumno no corresponde" });

            var profesor = await _profesorService.UpdateProfesorAsync(id, updatedProfesor);

            if (!profesor) return NotFound();

            return Ok(new { status = "Ok", result = new { alumno = updatedProfesor } });
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProfesor(Guid id)
        {
            var alumno = await _profesorService.DeleteProfesor(id);

            if (!alumno) return NotFound();

            return Ok(new { status = "Ok", result = "Alumno eliminado exitosamente" });
        }
    }
}
