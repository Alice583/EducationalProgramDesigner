using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.RepositoriesInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Objects.Repositories;

public class SubjectRepository : ISubjectRepository
{
    public Dictionary<Guid, ISubject> RepositorySubject { get; private set; }

    public SubjectRepository()
    {
        RepositorySubject = new Dictionary<Guid, ISubject>();
    }

    public void Add(ISubject subject)
    {
        RepositorySubject[subject.Id] = subject;
    }

    public Guid? Remove(Guid id)
    {
        if (!RepositorySubject.Remove(id))
        {
            return null;
        }

        return id;
    }

    public ISubject? GetById(Guid id)
    {
        if (RepositorySubject.TryGetValue(id, out ISubject? subject))
        {
            return subject;
        }

        return null;
    }
}