using Application.Common.ApiModels.MovieDTOs;
using Application.Common.Interfaces;
using Application.CQRS.Movies.Command;
using MediatR;

namespace Application.CQRS.Movies.EventHandlers;

public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, MovieDTO>
{
    private readonly IMovieService _movieService;

    public UpdateMovieCommandHandler(IMovieService movieService)
    {
        _movieService = movieService;
    }

    public async Task<MovieDTO> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        return await _movieService.UpdateMovieAsync(request.MovieId, request.UpdateMovieDto);
    }
}