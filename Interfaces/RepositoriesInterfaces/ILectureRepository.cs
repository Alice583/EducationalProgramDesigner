namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces.RepositoriesInterfaces;

public interface ILectureRepository
{
    void Add(ILecture lecture);

    Guid? Remove(Guid id);

    ILecture? GetById(Guid id);
}