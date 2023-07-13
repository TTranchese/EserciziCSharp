using Microsoft.EntityFrameworkCore;

namespace EseFilm.Models;

public class SitoFilmContext : DbContext
{
    public DbSet<Film> Films { get; set; }
    public SitoFilmContext(DbContextOptions<SitoFilmContext> options) : base(options) {}
}