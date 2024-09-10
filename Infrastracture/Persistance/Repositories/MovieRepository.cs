using Domain.Entities;
using Domain.SharedKernel.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Persistance.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly ApplicationDbContext _dbContext;

    public MovieRepository(ApplicationDbContext  dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Movie>> GetMoviesAsync()
    {
        return await _dbContext.Movies.Include(d=>d.Director).ToListAsync();
    }
    
    public async Task<Movie> GetMovieByIdAsync(Guid id)
    {
        return await _dbContext.Movies
            .Include(m => m.Director)
            .FirstOrDefaultAsync(m => m.Id == id);
    }
    
    public async Task<Director> GetDirectorByIdAsync(Guid directorId)
    {
        return await _dbContext.Directors.FindAsync(directorId);
    }
    
    public async Task AddMovieAsync(Movie movie)
    {
        await _dbContext.Movies.AddAsync(movie);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task UpdateMovieAsync(Movie movie)
    {
        _dbContext.Movies.Update(movie);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteMovieAsync(Movie movie)
    {
        _dbContext.Movies.Remove(movie);
        await _dbContext.SaveChangesAsync();
    }
}