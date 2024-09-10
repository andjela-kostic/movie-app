using Domain.Entities.Common;

namespace Domain.Entities;

public class Actor: Person
{
    public Actor(){}

    public Actor(Guid id, string firstName, string lastName) : base(id, firstName, lastName)
    {
    }
}