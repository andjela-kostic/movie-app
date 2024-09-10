using Application.Common.ApiModels.MovieDTOs;
using MediatR;

namespace Application.CQRS.Movies.Queries;

public record GetMoviesQuery : IRequest<IEnumerable<MovieDTO>>;