﻿using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<List<Grado>>> GetGrados()
        {
            var grados = await _gradosAlumnosService.GetGradosAsync();

            if(grados == null || !grados.Any()) return NotFound();

            return Ok(grados);
        }

        [HttpPost("Grados")]
        public async Task<ActionResult<Grado>> CreateGrado([FromBody] Grado grado)
        {
            if (!ModelState.IsValid) return BadRequest(new { status = "Error", result = ModelState });

            var createdGrado = await _gradosAlumnosService.CreateGradoAsync(grado);

            return CreatedAtAction(nameof(createdGrado), new { id = createdGrado.Id }, new { status = "Ok", result = new { grado = createdGrado } });
        }

        [HttpPut("Grados")]
        public async Task<ActionResult> UpdateGrado(int id, [FromBody] Grado updatedGrado)
        {
            if (id != updatedGrado.Id) return BadRequest(new { status = "Error", result = "El Id del grado no corresponde" });

            var grado = await _gradosAlumnosService.UpdateGradoAsync(id, updatedGrado);

            if(!grado) return NotFound();

            return Ok(new { status = "Ok", result = "Grado actualizado exitosamente." });
        }

        [HttpDelete("Grados")]
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
        public async Task<ActionResult<AlumnoGrado>> CreateAlumnoGrado([FromBody] AlumnoGrado alumnoGrado)
        {
            if (!ModelState.IsValid) return BadRequest(new { status = "Error", result = ModelState });

            var createdAlumnoGrado = await _gradosAlumnosService.CreateAlumnoGradoAsync(alumnoGrado);

            return CreatedAtAction(nameof(createdAlumnoGrado), new { id = createdAlumnoGrado.Id }, new { status = "Ok", result = new { grado = createdAlumnoGrado } });
        }

        [HttpPut("GradosAlumnos")]
        public async Task<ActionResult> UpdateAlumnoGrado(int id, [FromBody] AlumnoGrado updatedAlumnoGrado)
        {
            if (id != updatedAlumnoGrado.Id) return BadRequest(new { status = "Error", result = "El Id del grado no corresponde" });

            var alumnoGrado = await _gradosAlumnosService.UpdateAlumnoGradoAsync(id, updatedAlumnoGrado);

            if (!alumnoGrado) return NotFound();

            return Ok(new { status = "Ok", result = "Grado actualizado exitosamente." });
        }

        [HttpDelete("GradosAlumnos")]
        public async Task<ActionResult> DeleteAlumnoGrado(int id)
        {
            var alumnoGrado = await _gradosAlumnosService.DeleteAlumnoGradoAsync(id);

            if (!alumnoGrado) return NotFound();

            return Ok(new { status = "Ok", result = "Grado eliminado exitosamente." });
        }
    }
}
