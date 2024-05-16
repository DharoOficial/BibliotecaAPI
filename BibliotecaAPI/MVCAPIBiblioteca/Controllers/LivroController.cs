using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCAPIBiblioteca.Context;
using MVCAPIBiblioteca.Models;
using MVCAPIBiblioteca.Models.DTOs;
using MVCAPIBiblioteca.Repositories;

namespace MVCAPIBiblioteca.Controllers;
[ApiController]
[Route("[controller]")]
public class LivroController : ControllerBase
{
    [HttpPost]
    [Authorize(policy: "Adimim")]
    public IActionResult AdicionarLivro([FromBody] LivroDTOsAutor livro, [FromServices] LivroRepositories livroRepositories, [FromServices] AutorRepositorie autorRepositorie)
    {
        LivroDTOsAutor livroAdd = livroRepositories.AdicionarLivro(livro);
        if(livroAdd != null)
        {
            autorRepositorie.AdicionarLivroAutor(livroAdd, livroAdd.IdAutor.ToString());
        }

        if (livroAdd is null) { return NoContent(); } else { return Ok(livroAdd); }
    }

    [HttpGet]
    public IEnumerable<Livro> BuscarLivro([FromServices] LivroRepositories livroRepositories)
    {

        return livroRepositories.GetLivros().ToList().Take(10);
    }

    [HttpGet("/{id}")]
    public IActionResult BuscarLivro([FromServices] LivroRepositories livroRepositories, string id)
    {
        Livro livro = livroRepositories.GetLivroById(id);
        if (livro is null) { return NotFound(); } else { return Ok(livro); }
    }
    [HttpPut]
    [Authorize(policy: "Adimim")]
    public IActionResult AtualizarLivro([FromBody] Livro livro, [FromServices] LivroRepositories livroRepositories)
    {
        Livro livroAtt = livroRepositories.GetLivroById(livro.Id.ToString());
        if (livroAtt != null)
        {
            livroAtt.NomeLivro = livro.NomeLivro;
            livroAtt.DescLivro = livro.DescLivro;
            livroAtt.NumeroPagina = livro.NumeroPagina;
            livroRepositories.UpdateLivro(livroAtt);
            return Ok(livroAtt);
        }
        else
        {
            return NotFound();
        }
    }
    [HttpDelete("{id}")]
    [Authorize(policy: "Adimim")]
    public IActionResult RemoverLivro([FromServices] LivroRepositories livroRepositories, string id)
    {
        Livro livro = livroRepositories.DeleteLivro(id);
        if (livro is null) { return NotFound(); } else { return Ok(livro); }
    }

}
