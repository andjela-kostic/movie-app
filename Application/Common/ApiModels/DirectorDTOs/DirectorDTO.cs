namespace Application.Common.ApiModels.DirectorDTOs;

public class DirectorDTO
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public DirectorDTO(Guid id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }
}