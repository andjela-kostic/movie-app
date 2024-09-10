namespace Domain.Entities;

public class Genre
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Genre() { }

    public Genre(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}