using Application.Common.ApiModels.MovieDTOs;
using Application.Common.Interfaces;
using Application.CQRS.Movies.Command;
using MediatR;

namespace Application.CQRS.Movies.EventHandlers;

public class AddMovieCommandHandler : IRequestHandler<AddMovieCommand, MovieDTO>
{
    private readonly IMovieService _movieService;

    public AddMovieCommandHandler(IMovieService movieService)
    {
        _movieService = movieService;
    }

    public async Task<MovieDTO> Handle(AddMovieCommand request, CancellationToken cancellationToken)
    {
        return await _movieService.AddMovieAsync(request.CreateMovieDto);
    }
}