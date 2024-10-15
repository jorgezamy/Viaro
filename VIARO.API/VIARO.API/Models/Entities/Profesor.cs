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
        public string Apellidos { get; set; } = "";

        [Required]
        public string Genero { get; set; } = "";

        public ICollection<Grado> Grados { get; set; } = new List<Grado>();
    }
}
