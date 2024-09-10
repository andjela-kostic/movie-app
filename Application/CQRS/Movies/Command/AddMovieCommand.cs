using Application.Common.ApiModels.MovieDTOs;
using MediatR;

namespace Application.CQRS.Movies.Command;

public class AddMovieCommand : IRequest<MovieDTO>
{
    public CreateMovieDTO CreateMovieDto { get; }

    public AddMovieCommand(CreateMovieDTO createMovieDto)
    {
        CreateMovieDto = createMovieDto;
    }
}