using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCAPIBiblioteca.Models;
using MVCAPIBiblioteca.Models.DTOs;
using MVCAPIBiblioteca.Repositories;

namespace MVCAPIBiblioteca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutorController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Autor> GetAutor([FromServices] AutorRepositorie autorRepositorie)
        {
            try
            {
                List<Autor> autoGet = autorRepositorie.GetAutor().ToList();
                return autoGet;
            }catch (Exception ex)
            {
                return Enumerable.Empty<Autor>();
            }
        }
        [HttpGet("{id}")]
        public IActionResult BuscarAutorPorId([FromServices] AutorRepositorie autorRepositorie,string id)
        {
            Autor autorId = autorRepositorie.GetAutorById(id);
            if (autorId != null)
            {
                return Ok(autorId);
            }
            else { return NotFound(); }
        }
        [HttpPost]
        [Authorize(policy: "Adimim")]
        public IActionResult AdicionarAutor([FromBody] CreateAutorDTOs autor, [FromServices] AutorRepositorie autorRepositorie)
        {
            try
            {
                autorRepositorie.AdicionarAutor(autor);
                return Ok(autor);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        [Authorize(policy: "Adimim")]
        public IActionResult RemoverAutor( [FromServices] AutorRepositorie autorRepositorie, string id)
        {
            try
            {
                Autor autordDel = autorRepositorie.DeleteAutor(id);
                if (autordDel != null)
                {
                    return Ok(autordDel);
                }
                else { return NotFound(); }
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Authorize(policy: "Adimim")]
        public IActionResult AtualizarAutor([FromBody] Autor autor, [FromServices] AutorRepositorie autorRepositorie)
        {
            try
            {
                Autor autorAtt = autorRepositorie.GetAutorById(autor.Id.ToString());
                if (autorAtt != null)
                {
                    autorAtt.NomeAutor = autor.NomeAutor;
                    autorAtt.Bio = autor.Bio;
                    autorRepositorie.UpdateAutor(autorAtt);
                    return Ok(autorAtt);
                }
                else { return NotFound(); }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
