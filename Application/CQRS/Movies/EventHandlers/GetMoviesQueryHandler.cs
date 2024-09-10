using Application.Common.ApiModels.MovieDTOs;
using Application.Common.Interfaces;
using Application.CQRS.Movies.Queries;
using MediatR;

namespace Application.CQRS.Movies.EventHandlers;

public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, IEnumerable<MovieDTO>>
{
    private readonly IMovieService _movieService;

    public GetMoviesQueryHandler(IMovieService movieService)
    {
        _movieService = movieService;
    }
    
    public async Task<IEnumerable<MovieDTO>> Handle(GetMoviesQuery request,
        CancellationToken cancellationToken)
    {
        return await _movieService.GetMoviesAsync();
    }
    
}