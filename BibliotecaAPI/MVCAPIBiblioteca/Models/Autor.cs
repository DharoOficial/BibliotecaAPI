using MVCAPIBiblioteca.Models.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCAPIBiblioteca.Models
{
    public class Autor
    {
        public Autor(){}
        public Autor(string nome)
        {
            Id=Guid.NewGuid();
            NomeAutor = nome;
            Livros = new List<LivroDTOsAutor>();
        }
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Nome do Autor não pode ser nulo")]
        [MaxLength(300,ErrorMessage = "Nome do Autor deve conter menos de 300 caracteres")]
        public string NomeAutor { get; set; }
        [MaxLength(600,ErrorMessage = "Bio deve conter menos de 600 caracteres")]
        public  string? Bio {  get; set; }

        //O post do Autor para de funcionar se descomentar o codigo a baixo
        public virtual ICollection<LivroDTOsAutor> Livros { get; set; }
    }
}
