using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Objects;

namespace Itmo.ObjectOrientedProgramming.Lab2.IBuilders;

public interface IBuilderEducationalProgram
{
    IBuilderEducationalProgram AddName(string name);

    IBuilderEducationalProgram AddSubject(int semester, ISubject subject);

    IBuilderEducationalProgram AddAuthor(Person author);

    IEducationalProgram Build();
}