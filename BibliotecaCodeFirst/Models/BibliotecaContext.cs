using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1;

public class BibliotecaContext : DbContext
{
    public DbSet<Autore> Autori { get; set;}
    public DbSet<Editore> Editori { get; set;}
    public DbSet<Libro> Libri { get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-BKL8UFN;Initial Catalog=DBLibri;Integrated Security=True;Trust Server Certificate=True");
    }
}