using System.ComponentModel.DataAnnotations;

namespace VIARO.API.Models.Entities
{
    public class Alumno
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Nombre { get; set; } = "";

        [Required]
        public string Apellido { get; set; } = "";

        [Required]
        public string Genero { get; set; } = "";

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
    }
}