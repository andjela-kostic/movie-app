using MediatR;

namespace Application.CQRS.Movies.Command;

public class DeleteMovieCommand: IRequest
{
    public Guid MovieId { get; }

    public DeleteMovieCommand(Guid movieId)
    {
        MovieId = movieId;
    }
}