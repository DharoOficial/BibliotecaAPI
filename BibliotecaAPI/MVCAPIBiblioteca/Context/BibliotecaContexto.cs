using Microsoft.EntityFrameworkCore;
using MVCAPIBiblioteca.Models;
using System.Collections.Specialized;

namespace MVCAPIBiblioteca.Context;

public class BibliotecaContexto: DbContext
{
    private string stringConection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=APIBiblioteca;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
    public DbSet<Livro> Livro {  get; set; }
    public DbSet<Autor> Autores { get; set; }
    public DbSet<Usuarios> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(stringConection).UseLazyLoadingProxies();

    }
}