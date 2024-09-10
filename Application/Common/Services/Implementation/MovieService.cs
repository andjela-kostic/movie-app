using Application.Common.ApiModels.MovieDTOs;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.SharedKernel.Interfaces.Repository;

namespace Application.Common.Services.Implementation;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;

    public MovieService(IMovieRepository movieRepository, IMapper mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MovieDTO>> GetMoviesAsync()
    {
        var movies = await _movieRepository.GetMoviesAsync();

        if (movies == null)
        {
            return Enumerable.Empty<MovieDTO>();
        }

        return _mapper.Map<IEnumerable<MovieDTO>>(movies);
    }
    
    public async Task<MovieDTO> GetMovieByIdAsync(Guid id)
    {
        var movie = await _movieRepository.GetMovieByIdAsync(id);

        if (movie == null)
        {
            return null; 
        }

        return _mapper.Map<MovieDTO>(movie);
    }

    public async Task<MovieDTO> AddMovieAsync(CreateMovieDTO createMovieDto)
    {
        var movie = _mapper.Map<Movie>(createMovieDto);

        var director = await _movieRepository.GetDirectorByIdAsync(createMovieDto.DirectorId); 
        
        if (director == null)
        {
            throw new ArgumentException("Director not found");
        }
        movie.Director = director;

        await _movieRepository.AddMovieAsync(movie);
        return _mapper.Map<MovieDTO>(movie);
    }
    
    public async Task<MovieDTO> UpdateMovieAsync(Guid movieId, UpdateMovieDTO updateMovieDto)
    {
        var movie = await _movieRepository.GetMovieByIdAsync(movieId);
        if (movie == null)
        {
            throw new ArgumentException("Movie not found");
        }

        movie.Title = updateMovieDto.Title;
        movie.ReleaseDate = updateMovieDto.ReleaseDate;

        var director = await _movieRepository.GetDirectorByIdAsync(updateMovieDto.DirectorId);
        if (director == null)
        {
            throw new ArgumentException("Director not found");
        }
        movie.Director = director;

        await _movieRepository.UpdateMovieAsync(movie);
        return _mapper.Map<MovieDTO>(movie);
    }
    
    public async Task DeleteMovieAsync(Guid movieId)
    {
        var movie = await _movieRepository.GetMovieByIdAsync(movieId);
        if (movie == null)
        {
            throw new ArgumentException("Movie not found.");
        }

        _movieRepository.DeleteMovieAsync(movie);
    }
}