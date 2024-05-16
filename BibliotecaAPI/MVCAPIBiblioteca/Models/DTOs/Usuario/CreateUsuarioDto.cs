using System.ComponentModel.DataAnnotations;

namespace MVCAPIBiblioteca.Models.DTOs.Usuario
{
    public class CreateUsuarioDto
    {
        [Required]
        public string NomeUsuario { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set;}
    }
}
