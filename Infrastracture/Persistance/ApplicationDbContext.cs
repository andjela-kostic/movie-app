using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Persistance;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<MovieGenre> MovieGenres { get; set; }
    public DbSet<MovieActor> MovieActors { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        modelBuilder.Entity<MovieGenre>()
            .HasKey(x => new { x.GenreId, x.MovieId });

        modelBuilder.Entity<MovieActor>()
            .HasKey(x => new { x.MovieId, x.ActorId });
    }
}