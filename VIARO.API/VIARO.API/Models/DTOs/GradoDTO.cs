using System.ComponentModel.DataAnnotations;

namespace VIARO.API.Models.DTOs
{
    public class GradoDTO
    {
        public int? Id {  get; set; }

        [Required(ErrorMessage ="El nombre no puede estar vacio")]
        public string Nombre { get; set; } = "";

        [Required(ErrorMessage ="el profesor Id es obligatorio")]
        public Guid ProfesorId { get; set; }
    }
}
