using Domain.Entities.Common;

namespace Domain.Entities;

public class Director : Person
{
    public Director() { }

    public Director(Guid id, string firstName, string lastName)
        : base(id, firstName, lastName)
    {
    }
}