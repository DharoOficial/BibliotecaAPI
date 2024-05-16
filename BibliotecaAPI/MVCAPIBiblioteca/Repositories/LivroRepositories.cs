using MVCAPIBiblioteca.Context;
using MVCAPIBiblioteca.Models;
using MVCAPIBiblioteca.Models.DTOs;

namespace MVCAPIBiblioteca.Repositories
{
    public class LivroRepositories
    {
        private readonly BibliotecaContexto _context;

        public LivroRepositories(BibliotecaContexto context)
        {
            _context = context;
        }
        
        public LivroDTOsAutor AdicionarLivro(LivroDTOsAutor livroDtos)
        {
            Livro livro = new Livro(livroDtos.NomeLivro,livroDtos.NumeroPagina,livroDtos.IdAutor);
            livroDtos.Id = livro.Id;
            try
            {
               _context.Livro.Add(livro);
               _context.SaveChanges();
               return livroDtos;
            }catch (Exception ex)
            {
                return null;
            }
        }
        public IEnumerable<Livro> GetLivros()
        {
            try
            {
                List<Livro> listaLivro = _context.Livro.ToList();
                return listaLivro;
            }catch(Exception ex)
            {
                return Enumerable.Empty<Livro>();
            }
        }
        public Livro GetLivroById(string id)
        {
            try
            {
                return _context.Livro.FirstOrDefault(x=>x.Id.ToString() == id)!;
            }catch(Exception ex)
            {
                return new Livro();
            }
        }
        public Livro UpdateLivro(Livro livro)
        {
            try
            {
                _context.Livro.Update(livro);
                _context.SaveChanges();
                return livro;
            }catch( Exception ex) { 
                return new Livro();
            }
        }
        public Livro DeleteLivro(string id)
        {
            try
            {
                Livro livroRm = GetLivroById(id);
                if (livroRm != null)
                {
                    _context.Livro.Remove(livroRm);
                    _context.SaveChanges();
                    return livroRm;
                }
                else
                {
                    return new Livro();
                }
            }
            catch
            {
                return new Livro();
            }
        }
    }
}
