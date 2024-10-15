using System.ComponentModel.DataAnnotations;

namespace VIARO.API.Models.Entities
{
    public class AlumnoGrado
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid AlumnoId { get; set; }

        [Required]
        public int GradoId { get; set; }

        [Required]
        public string Seccion { get; set; } = "";


        public Alumno? Alumno { get; set; }
        public Grado? Grado { get; set; }
    }
}
