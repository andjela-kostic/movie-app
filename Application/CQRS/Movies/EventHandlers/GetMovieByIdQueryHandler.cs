using Application.Common.ApiModels.MovieDTOs;
using Application.Common.Interfaces;
using Application.CQRS.Movies.Queries;
using MediatR;

namespace Application.CQRS.Movies.EventHandlers;

public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, MovieDTO>
{
    private readonly IMovieService _movieService;

    public GetMovieByIdQueryHandler(IMovieService movieService)
    {
        _movieService = movieService;
    }

    public async Task<MovieDTO> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
    {
        return await _movieService.GetMovieByIdAsync(request.Id);
    }
}