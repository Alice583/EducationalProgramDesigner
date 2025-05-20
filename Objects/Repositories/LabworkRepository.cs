using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.RepositoriesInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Objects.Repositories;

public class LabworkRepository : ILabworkRepository
{
    public Dictionary<Guid, ILabwork> RepositoryLabworks { get; private set; }

    public LabworkRepository()
    {
        RepositoryLabworks = new Dictionary<Guid, ILabwork>();
    }

    public void Add(ILabwork labwork)
    {
        RepositoryLabworks[labwork.Id] = labwork;
    }

    public Guid? Remove(Guid id)
    {
        if (!RepositoryLabworks.Remove(id))
        {
            return null;
        }

        return id;
    }

    public ILabwork? GetById(Guid id)
    {
        if (RepositoryLabworks.TryGetValue(id, out ILabwork? labwork))
        {
            return labwork;
        }

        return null;
    }
}