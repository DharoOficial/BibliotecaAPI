using System.ComponentModel.DataAnnotations;

namespace MVCAPIBiblioteca.Models.DTOs.Usuario
{
    public class LoginUsuario
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
