using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCAPIBiblioteca.Models;
using MVCAPIBiblioteca.Models.DTOs.Usuario;
using MVCAPIBiblioteca.Repositories;
using System.Net;

namespace MVCAPIBiblioteca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpPost("Cadastro")]
        public IActionResult CadastroUsuario([FromBody]CreateUsuarioDto userDto, [FromServices] UsuarioRepositories usuarioRepositories)
        {
            try
            {
                Usuarios user = usuarioRepositories.CadastrarUsuario(userDto);
                return Ok(user);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginUsuario userLogin, [FromServices] UsuarioRepositories usuarioRepositories)
        {
            try
            {
                string userLogedIn = usuarioRepositories.Login(userLogin);
                if (userLogedIn != null)
                    return Ok(userLogedIn);
                return NotFound();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetUsuarios([FromServices] UsuarioRepositories usuarioRepositories)
        {
            try
            {
                List<Usuarios> listaUsuarios = usuarioRepositories.GetUsuarios().ToList();
                return Ok(listaUsuarios);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("id")]
        public IActionResult GetUsuarios([FromServices] UsuarioRepositories usuarioRepositories, string id)
        {
            try
            {
                Usuarios UsuarioId = usuarioRepositories.GetUsuariosById(id);
                if (UsuarioId == null)
                    return NotFound();
                return Ok(UsuarioId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(policy: "Adimim")]
        public IActionResult UpdateUsuario([FromBody] Usuarios usuario, [FromServices] UsuarioRepositories usuarioRepositories, string id)
        {
            try
            {
                Usuarios usuarioId = usuarioRepositories.GetUsuariosById(id);
                if (usuarioId == null)
                    return NotFound();
                usuarioId.NomeCompleto = usuario.NomeCompleto;
                usuarioId.NomeUsuario = usuario.NomeUsuario;
                usuarioId.DataNascimento = usuario.DataNascimento;
                usuarioId.Email = usuario.Email;
                usuarioRepositories.UpdateUsuarios(usuarioId);
                return Ok(usuarioId);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(policy: "Adimim")]
        public IActionResult DeleteUsuario([FromServices] UsuarioRepositories usuarioRepositories, string id)
        {
            try
            {
                Usuarios usuario = usuarioRepositories.GetUsuariosById(id);
                if (usuario == null)
                    return NotFound();
                Usuarios userDel = usuarioRepositories.DeleteUsuario(usuario);
                return Ok(userDel);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("AlterarRole/{id}")]
        [Authorize(policy: "Adimim")]
        public IActionResult AlterarRole([FromServices] UsuarioRepositories usuarioRepositories, string id)
        {
            try
            {
                Usuarios usuarioAlt = usuarioRepositories.GetUsuariosById(id);
                if (usuarioAlt == null)
                    return NotFound();
                if (usuarioAlt.Role == 0)
                    usuarioAlt.Role = 1;
                else { 
                    usuarioAlt.Role = 0;
                }
                usuarioRepositories.UpdateUsuarios(usuarioAlt);
                return Ok(usuarioAlt);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
