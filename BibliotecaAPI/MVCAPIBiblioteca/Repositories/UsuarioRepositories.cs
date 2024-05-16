using Microsoft.AspNetCore.Mvc;
using MVCAPIBiblioteca.Context;
using MVCAPIBiblioteca.Models;
using MVCAPIBiblioteca.Models.DTOs.Usuario;
using MVCAPIBiblioteca.Utils;
using System.IdentityModel.Tokens.Jwt;

namespace MVCAPIBiblioteca.Repositories
{
    public class UsuarioRepositories
    {
        private readonly BibliotecaContexto _context;

        public UsuarioRepositories(BibliotecaContexto context)
        {
            _context = context;
        }

        public Usuarios CadastrarUsuario(CreateUsuarioDto userDto)
        {
            Usuarios usuario = new Usuarios(userDto.NomeUsuario,userDto.Email,userDto.Password);
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public string Login(LoginUsuario userDto)
        {
            Usuarios userLogin = _context.Usuarios.FirstOrDefault(x => x.Password == userDto.Password && x.Email == userDto.Email)!;
            if (userLogin == null)
                return null;
            var token = TokenJwt<Usuarios>.GerarToken(userLogin);
            return token;
        }

        public IEnumerable<Usuarios> GetUsuarios()
        {
            List<Usuarios> listaUsuarios = _context.Usuarios.ToList();
            return listaUsuarios;
        }

        public Usuarios GetUsuariosById (string id)
        {
            Usuarios usuarioId = _context.Usuarios.FirstOrDefault(x => x.Id.ToString() == id)!;
            if (usuarioId == null)
                return null;
            return usuarioId;
        }

        public Usuarios UpdateUsuarios (Usuarios usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public Usuarios DeleteUsuario(Usuarios usuarios)
        {
            _context.Usuarios.Remove(usuarios);
            _context.SaveChanges();
            return usuarios;
        }
    }
}
