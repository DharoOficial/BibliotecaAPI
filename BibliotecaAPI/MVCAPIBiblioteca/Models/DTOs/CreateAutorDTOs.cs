using System.ComponentModel.DataAnnotations;

namespace MVCAPIBiblioteca.Models.DTOs
{
    public class CreateAutorDTOs
    {
        [Required(ErrorMessage = "Nome do Autor não pode ser nulo")]
        [MaxLength(300, ErrorMessage = "Nome do Autor deve conter menos de 300 caracteres")]
        public string NomeAutor { get; set; }
        [MaxLength(600, ErrorMessage = "Bio deve conter menos de 600 caracteres")]
        public string? Bio { get; set; }

    }
}
