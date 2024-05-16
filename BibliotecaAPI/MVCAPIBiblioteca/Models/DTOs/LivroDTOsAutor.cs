using System.ComponentModel.DataAnnotations;

namespace MVCAPIBiblioteca.Models.DTOs
{
    public class LivroDTOsAutor
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O Nome do Livro de ser informado")]
        [MaxLength(300, ErrorMessage = "O Nome do Livro dever ter menos que 300 caracteres")]
        public string NomeLivro { get; set; }
        [MaxLength(600, ErrorMessage = "A descrição do livro dever ter menos que 600 caracteres")]
        public string? DescLivro { get; set; }
        [Required(ErrorMessage = "O numero de paginas deve ser informado")]
        [Range(0, 10000, ErrorMessage = "O numero de paginas do livro dever estar entre 0 e 10.000")]
        public int NumeroPagina { get; set; }
        [Required]
        public string IdAutor { get; set; }
    }
}
