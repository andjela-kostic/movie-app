using Application.Common.ApiModels.ActorDTOs;
using Application.Common.ApiModels.DirectorDTOs;

namespace Application.Common.ApiModels.MovieDTOs;

public class MovieDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public DirectorDTO Director { get; set; }
    

    public MovieDTO(Guid id, string title, DateOnly releaseDate, DirectorDTO director)
    {
        Id = id;
        Title = title;
        ReleaseDate = releaseDate;
        Director = director;
    }
}