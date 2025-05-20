namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces.RepositoriesInterfaces;

public interface ISubjectRepository
{
    void Add(ISubject subject);

    Guid? Remove(Guid id);

    ISubject? GetById(Guid id);
}