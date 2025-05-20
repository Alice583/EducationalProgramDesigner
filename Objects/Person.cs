using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Objects;

public class Person : IPerson
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public Person(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    private Person(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Person Copy()
    {
        return new Person(Id, Name);
    }
}