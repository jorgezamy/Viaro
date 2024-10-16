using Microsoft.AspNetCore.Mvc;
using VIARO.API.Models.DTOs;
using VIARO.API.Models.Entities;
using VIARO.API.Services;
using VIARO.API.Services.interfaces;

namespace VIARO.API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class GradosController : ControllerBase
    {
        private readonly IGradosAlumnosService _gradosAlumnosService;

        public GradosController(IGradosAlumnosService gradosAlumnosService)
        {
            _gradosAlumnosService = gradosAlumnosService;
        }

        [HttpGet("Grados")]
        public async Task<ActionResult<List<GradoDTO>>> GetGrados()
        {
            var grados = await _gradosAlumnosService.GetGradosAsync();

            if(grados == null || !grados.Any()) return NotFound();

            return Ok(grados);
        }

        [HttpPost("Grados")]
        public async Task<ActionResult<GradoDTO>> CreateGrado([FromBody] GradoDTO gradoDTO)
        {
            if (!ModelState.IsValid) return BadRequest(new { status = "Error", result = ModelState });

            var createdGrado = await _gradosAlumnosService.CreateGradoAsync(gradoDTO);

            return CreatedAtAction(nameof(CreateGrado), new { id = createdGrado.Id }, new { status = "Ok", result = new { grado = createdGrado } });
        }

        [HttpPut("Grados/{id}")]
        public async Task<ActionResult> UpdateGrado(int id, [FromBody] GradoDTO updatedGrado)
        {
            if (id != updatedGrado.Id) return BadRequest(new { status = "Error", result = "El Id del grado no corresponde" });

            var grado = await _gradosAlumnosService.UpdateGradoAsync(id, updatedGrado);

            if(!grado) return NotFound();

            return Ok(new { status = "Ok", result = "Grado actualizado exitosamente." });
        }

        [HttpDelete("Grados/{id}")]
        public async Task<ActionResult> DeleteGrado(int id)
        {
            var grado = await _gradosAlumnosService.DeleteGradoAsync(id);

            if (!grado) return NotFound();

            return Ok(new { status = "Ok", result = "Grado eliminado exitosamente." });
        }

        [HttpGet("GradosAlumnos")]
        public async Task<ActionResult<List<Grado>>> GetGradosAlumnos()
        {
            var alumnoGrados = await _gradosAlumnosService.GetAlumnoGradosAsync();

            if (alumnoGrados == null || !alumnoGrados.Any()) return NotFound();

            return Ok(alumnoGrados);
        }

        [HttpPost("GradosAlumnos")]
        public async Task<ActionResult<AlumnoGradoDTO>> CreateAlumnoGrado([FromBody] AlumnoGradoDTO alumnoGrado)
        {
            if (!ModelState.IsValid) return BadRequest(new { status = "Error", result = ModelState });

            var createdAlumnoGrado = await _gradosAlumnosService.CreateAlumnoGradoAsync(alumnoGrado);

            return CreatedAtAction(nameof(createdAlumnoGrado), new { id = createdAlumnoGrado.Id }, new { status = "Ok", result = new { grado = createdAlumnoGrado } });
        }

        [HttpPut("GradosAlumnos/{id}")]
        public async Task<ActionResult> UpdateAlumnoGrado(int id, [FromBody] AlumnoGradoDTO updatedAlumnoGrado)
        {
            if (id != updatedAlumnoGrado.Id) return BadRequest(new { status = "Error", result = "El Id del grado no corresponde" });

            var alumnoGrado = await _gradosAlumnosService.UpdateAlumnoGradoAsync(id, updatedAlumnoGrado);

            if (!alumnoGrado) return NotFound();

            return Ok(new { status = "Ok", result = "Grado actualizado exitosamente." });
        }

        [HttpDelete("GradosAlumnos/{id}")]
        public async Task<ActionResult> DeleteAlumnoGrado(int id)
        {
            var alumnoGrado = await _gradosAlumnosService.DeleteAlumnoGradoAsync(id);

            if (!alumnoGrado) return NotFound();

            return Ok(new { status = "Ok", result = "Grado eliminado exitosamente." });
        }
    }
}
