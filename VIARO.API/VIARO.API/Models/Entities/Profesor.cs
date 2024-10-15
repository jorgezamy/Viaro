using System.ComponentModel.DataAnnotations;

namespace VIARO.API.Models.Entities
{
    public class Profesor
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Nombre { get; set; } = "";

        [Required]
        public string Apellidps { get; set; } = "";

        [Required]
        public string Genero { get; set; } = "";
    }
}
