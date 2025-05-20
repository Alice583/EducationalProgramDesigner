namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces.RepositoriesInterfaces;

public interface IEducationalProgramRepository
{
    void Add(IEducationalProgram educationalProgram);

    Guid? Remove(Guid id);

    IEducationalProgram? GetById(Guid id);
}