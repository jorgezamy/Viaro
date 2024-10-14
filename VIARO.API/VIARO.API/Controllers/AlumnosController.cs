using Microsoft.AspNetCore.Mvc;
using VIARO.API.Models.Entities;
using VIARO.API.Services;

namespace VIARO.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlumnosController : ControllerBase
    {
        private readonly AlumnoService _alumnoService;

        public AlumnosController(AlumnoService alumnoService)
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
                return BadRequest(new { status="Error", result = ModelState});
            }

            var createdAlumno = await _alumnoService.CreateAlumno(alumno);


            return CreatedAtAction(nameof(CreateAlumno), new { id = createdAlumno.Id }, new { status = "Ok", result = new { alumno = createdAlumno } });
        }
    }
}
