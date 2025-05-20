using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces.RepositoriesInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class SubjectChanges : ISubjectChanger
{
    private readonly ISubjectRepository _subjectRepository;

    public SubjectChanges(ISubjectRepository subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }

    public ISubject? Update(ISubject? newSubject)
    {
        if (newSubject == null)
        {
            return null;
        }

        ISubject? oldSubject = _subjectRepository.GetById(newSubject.Id);

        if (oldSubject is null)
        {
            return null;
        }

        if (oldSubject.CheckCorrectAuthor(newSubject.Author))
        {
            if (CheckSubjectUpdation(newSubject, oldSubject))
            {
                _subjectRepository.Remove(oldSubject.Id);
                _subjectRepository.Add(newSubject);

                return newSubject;
            }

            return null;
        }

        return null;
    }

    private bool CheckSubjectUpdation(ISubject firstSubject, ISubject secondSubject)
    {
        return firstSubject.Id == secondSubject.Id &&
               firstSubject.Author == secondSubject.Author &&
               firstSubject.Exam == secondSubject.Exam &&
               firstSubject.Credit == secondSubject.Credit &&
               IsLabworksValid(firstSubject.Labworks, secondSubject.Labworks);
    }

    private bool IsLabworksValid(IList<ILabwork> first, IList<ILabwork> second)
    {
        foreach (ILabwork firstLabwork in second)
        {
            if (!first.Contains(firstLabwork))
            {
                return false;
            }
        }

        return true;
    }
}