using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Objects;

namespace Itmo.ObjectOrientedProgramming.Lab2.IBuilders;

public interface IBuilderLecture
{
    IBuilderLecture AddName(string name);

    IBuilderLecture AddDescription(string description);

    IBuilderLecture AddContent(string content);

    IBuilderLecture AddAuthor(Person author);

    ILecture Build();
}