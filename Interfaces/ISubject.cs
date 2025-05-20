using Itmo.ObjectOrientedProgramming.Lab2.Objects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

public interface ISubject
{
     Guid Id { get; }

     Guid? IdCopy { get; }

     int? Exam { get; }

     int? Credit { get; }

     IList<ILecture> Lectures { get; }

     IList<ILabwork> Labworks { get; }

     string Name { get; }

     Person Author { get; }

     ISubject Copy();

     bool CheckCorrectAuthor(Person author);
}