namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces.RepositoriesInterfaces;

public interface ILabworkRepository
{
    void Add(ILabwork labwork);

    Guid? Remove(Guid id);

    ILabwork? GetById(Guid id);
}