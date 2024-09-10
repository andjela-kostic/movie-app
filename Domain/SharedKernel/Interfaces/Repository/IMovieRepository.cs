using Domain.Entities;

namespace Domain.SharedKernel.Interfaces.Repository;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetMoviesAsync();
    Task<Movie> GetMovieByIdAsync(Guid id);
    Task AddMovieAsync(Movie movie);
    Task UpdateMovieAsync(Movie movie);
    Task<Director> GetDirectorByIdAsync(Guid directorId);
    
    Task DeleteMovieAsync(Movie movie);
}