using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Objects;

namespace Itmo.ObjectOrientedProgramming.Lab2.IBuilders;

public interface IBuilderLabwork
{
    IBuilderLabwork AddName(string name);

    IBuilderLabwork AddDescription(string description);

    IBuilderLabwork AddCriteries(string criteries);

    IBuilderLabwork AddMark(int mark);

    IBuilderLabwork AddAuthor(Person author);

    ILabwork Build();
}