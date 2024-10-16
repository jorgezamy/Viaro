using System.ComponentModel.DataAnnotations;

namespace VIARO.API.Models.DTOs
{
    public class AlumnoGradoDTO
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Se requiere seleccionar un alumno")]
        public Guid AlumnoId { get; set; }

        [Required(ErrorMessage = "Se requiere seleccionar un grado")]
        public int GradoId { get; set; }

        [Required(ErrorMessage = "La sección no puede estar vacia")]
        public string Seccion { get; set; } = "";

    }
}
