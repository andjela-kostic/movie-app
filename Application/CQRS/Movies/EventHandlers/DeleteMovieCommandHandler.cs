using Application.Common.Interfaces;
using Application.CQRS.Movies.Command;
using MediatR;

namespace Application.CQRS.Movies.EventHandlers;

public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand>
{
    private readonly IMovieService _movieService;

    public DeleteMovieCommandHandler(IMovieService movieService)
    {
        _movieService = movieService;
    }

    public async Task<Unit> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        await _movieService.DeleteMovieAsync(request.MovieId);
        return Unit.Value;
    }
}