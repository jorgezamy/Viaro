using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using VIARO.API.Models.Entities;
using VIARO.API.Services;
using VIARO.API.Services.interfaces;

namespace VIARO.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlumnosController : ControllerBase
    {
        private readonly IAlumnoService _alumnoService;

        public AlumnosController(IAlumnoService alumnoService)
        {
            _alumnoService = alumnoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Alumno>>> GetAlumnos()
        {
            var alumnos = await _alumnoService.GetAlumnos();

            if (alumnos == null || !alumnos.Any())
            {
                return NotFound();
            }

            return Ok(alumnos);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAlumno([FromBody] Alumno alumno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { status = "Error", result = ModelState });
            }

            var createdAlumno = await _alumnoService.CreateAlumno(alumno);


            return CreatedAtAction(nameof(CreateAlumno), new { id = createdAlumno.Id }, new { status = "Ok", result = new { alumno = createdAlumno } });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAlumno(Guid id, [FromBody] Alumno updatedAlumno)
        {
            if (id != updatedAlumno.Id) return BadRequest(new { status = "Error", result = "El ID del alumno no corresponde" });

            var alumno = await _alumnoService.UpdateAlumnoAsync(id, updatedAlumno);

            if (!alumno) return NotFound();

            return Ok(new { status = "Ok", result = new { alumno = updatedAlumno } });
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAlumno(int id)
        {
            var alumno = await _alumnoService.DeleteAlumno(id);

            if(!alumno) return NotFound();

            return Ok(new { status = "Ok", result = "Alumno eliminado exitosamente" });
        }
    }
}
