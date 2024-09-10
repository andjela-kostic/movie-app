namespace Domain.Entities;

public class MovieGenre
{
    public Guid MovieId { get; set; } 
    public Guid GenreId { get; set; }

    public Movie Movie { get; set; }
    public Genre Genre { get; set; }

    public MovieGenre() { }

    public MovieGenre(Guid movieId, Guid genreId)
    {
        MovieId = movieId;
        GenreId = genreId;
    }
}