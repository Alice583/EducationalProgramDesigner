namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

public interface IEducationalProgram
{
    Guid Id { get; }

    string Name { get; }

    Dictionary<int, IList<ISubject>> Subjects { get; }
}