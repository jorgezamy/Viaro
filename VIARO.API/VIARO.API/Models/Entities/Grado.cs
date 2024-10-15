using System.ComponentModel.DataAnnotations;

namespace VIARO.API.Models.Entities
{
    public class Grado
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = "";

        [Required]
        public Guid ProfesorId { get; set; }

        public Profesor? Profesor { get; set; }
    }
}
