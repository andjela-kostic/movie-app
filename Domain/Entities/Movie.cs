namespace Domain.Entities;

public class Movie
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public Director Director { get; set; }
    //public List<Actor> Actors { get; set; }

    public Movie() { }

    public Movie(Guid id, string title, DateOnly releaseDate, Director director)
    {
        Id = id;
        Title = title;
        ReleaseDate = releaseDate;
        Director = director;
    }
}