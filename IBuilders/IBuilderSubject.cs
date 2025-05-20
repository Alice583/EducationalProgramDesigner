using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Objects;

namespace Itmo.ObjectOrientedProgramming.Lab2.IBuilders;

public interface IBuilderSubject
{
     IBuilderSubject AddName(string name);

     IBuilderSubject AddLecture(ILecture lecture);

     IBuilderSubject AddLabwork(ILabwork labwork);

     IBuilderSubject AddExam(int examMark);

     IBuilderSubject AddCredit(int creditMark);

     IBuilderSubject AddAuthor(Person author);

     IBuilderSubject AddId(Guid id);

     ISubject? BuildWithoutId();

     ISubject? BuildWithId();
}