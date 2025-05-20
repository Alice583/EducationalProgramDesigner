using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.RepositoriesInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Objects.Repositories;

public class EducationalProgramRepository : IEducationalProgramRepository
{
    public Dictionary<Guid, IEducationalProgram> RepositoryEducationalProgram { get; private set; }

    public EducationalProgramRepository()
    {
        RepositoryEducationalProgram = new Dictionary<Guid, IEducationalProgram>();
    }

    public void Add(IEducationalProgram educationalProgram)
    {
        RepositoryEducationalProgram[educationalProgram.Id] = educationalProgram;
    }

    public Guid? Remove(Guid id)
    {
        if (!RepositoryEducationalProgram.Remove(id))
        {
            return null;
        }

        return id;
    }

    public IEducationalProgram? GetById(Guid id)
    {
        if (RepositoryEducationalProgram.TryGetValue(id, out IEducationalProgram? educationalProgram))
        {
            return educationalProgram;
        }

        return null;
    }
}