using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.RepositoriesInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Objects.Repositories;

public class LectureRepository : ILectureRepository
{
    public Dictionary<Guid, ILecture> RepositoryLectures { get; private set; }

    public LectureRepository()
    {
        RepositoryLectures = new Dictionary<Guid, ILecture>();
    }

    public void Add(ILecture lecture)
    {
        RepositoryLectures[lecture.Id] = lecture;
    }

    public Guid? Remove(Guid id)
    {
        if (!RepositoryLectures.Remove(id))
        {
            return null;
        }

        return id;
    }

    public ILecture? GetById(Guid id)
    {
        if (RepositoryLectures.TryGetValue(id, out ILecture? lecture))
        {
            return lecture;
        }

        return null;
    }
}