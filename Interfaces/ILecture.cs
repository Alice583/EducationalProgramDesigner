using Itmo.ObjectOrientedProgramming.Lab2.Objects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

public interface ILecture
{
    Guid Id { get; }

    Guid? IdCopy { get; }

    string Name { get; }

    string Description { get; }

    string Content { get; }

    Person Author { get; }

    bool EditName(Person author, string newName);

    bool EditDescription(Person author, string newDescription);

    bool EditContent(Person author, string newContent);

    ILecture Copy();
}