using Microsoft.AspNetCore.Mvc;
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

            if(grados == null) return NotFound();

            return Ok(grados);
        }

        [HttpGet("GradosAlumnos")]
        public async Task<ActionResult<List<Grado>>> GetGradosAlumnos()
        {
            var gradosAlumnos = await _gradosAlumnosService.GetAlumnoGradosAsync();

            if (gradosAlumnos == null) return NotFound();

            return Ok(gradosAlumnos);
        }
    }
}
