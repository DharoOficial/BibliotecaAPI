using System.ComponentModel.DataAnnotations;
using System.Data;

namespace MVCAPIBiblioteca.Models
{
    public class Usuarios
    {
        public Usuarios() { }
        public Usuarios(string nomeUsuario, string email, string senha)
        {
            NomeUsuario = nomeUsuario;
            Email = email;
            Password = senha;
            Id = Guid.NewGuid();
        }
        public Guid Id { get; private set; }
        public string NomeCompleto { get; set; } = string.Empty;
        [Required]
        public string NomeUsuario { get; set; }
        public DateTime DataNascimento { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public int Role { get; set; } = 0;

        //Role:
        //    0 = Usuarios,
        //    1 = Adimim

    }
}
