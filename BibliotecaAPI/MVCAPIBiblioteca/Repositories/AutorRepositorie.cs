using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MVCAPIBiblioteca.Context;
using MVCAPIBiblioteca.Models;
using MVCAPIBiblioteca.Models.DTOs;

namespace MVCAPIBiblioteca.Repositories
{
    public class AutorRepositorie
    {
        private readonly BibliotecaContexto _context;

        public AutorRepositorie(BibliotecaContexto context)
        {
            _context = context;
        }

        public Autor AdicionarAutor(CreateAutorDTOs autorDtos)
        {
            Autor autor = new Autor(autorDtos.NomeAutor);
            autor.Bio = autorDtos.Bio;
            try
            {
                _context.Autores.Add(autor);
                _context.SaveChanges();
                return autor;
            }catch (Exception ex)
            {
                return new Autor();
            }
        }
        public IEnumerable<Autor> GetAutor()
        {
            try
            {
                List<Autor> listaAutores = _context.Autores.ToList();
                return listaAutores;
            }catch(Exception ex)
            {
                return new List<Autor>();
            }
        }
        public Autor GetAutorById(string id)
        {
            try
            {
                return _context.Autores.FirstOrDefault(x => x.Id.ToString() == id)!;
            }
            catch
            {
                return new Autor();
            }
        }
        public Autor DeleteAutor(string id)
        {
            try
            {
                Autor autor = GetAutorById(id);
                _context.Autores.Remove(autor);
                _context.SaveChanges();
                return autor;
            }
            catch
            {
                return new Autor();
            }
        }
        public Autor UpdateAutor(Autor autor)
        {
            try
            {
                _context.Autores.Update(autor);
                _context.SaveChanges();
                return autor;
            }
            catch
            {
                return new Autor();
            }
        }
        public LivroDTOsAutor AdicionarLivroAutor(LivroDTOsAutor livro, string idAutor)
        {
            try
            {
                Autor autorAdd = GetAutorById(idAutor);
                if(autorAdd != null)
                {
                    autorAdd.Livros.Add(livro);
                    UpdateAutor(autorAdd);
                    return livro;
                }
                else { return null; }
            }
            catch {  return null; }
        }
    }
}
