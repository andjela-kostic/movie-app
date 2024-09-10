namespace Application.Common.ApiModels.MovieDTOs;

public class CreateMovieDTO
{
    public string Title { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public Guid DirectorId { get; set; }
}