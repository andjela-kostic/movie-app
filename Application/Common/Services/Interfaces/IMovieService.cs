using Application.Common.ApiModels.MovieDTOs;

namespace Application.Common.Interfaces;

public interface IMovieService
{
    Task<IEnumerable<MovieDTO>> GetMoviesAsync();
    Task<MovieDTO> GetMovieByIdAsync(Guid id);
    Task<MovieDTO> AddMovieAsync(CreateMovieDTO createMovieDto);
    Task<MovieDTO> UpdateMovieAsync(Guid movieId, UpdateMovieDTO updateMovieDto);
    Task DeleteMovieAsync(Guid movieId);

}