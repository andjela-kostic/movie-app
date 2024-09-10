using Application.Common.ApiModels.MovieDTOs;
using MediatR;

namespace Application.CQRS.Movies.Command;

public class UpdateMovieCommand : IRequest<MovieDTO>
{
    public Guid MovieId { get; }
    public UpdateMovieDTO UpdateMovieDto { get; }

    public UpdateMovieCommand(Guid movieId, UpdateMovieDTO updateMovieDto)
    {
        MovieId = movieId;
        UpdateMovieDto = updateMovieDto;
    }
}