using Itmo.ObjectOrientedProgramming.Lab2.Objects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

public interface ILabwork
{
      Guid Id { get; }

      Guid? IdCopy { get; }

      string Name { get; }

      string Description { get; }

      string Criteries { get; }

      int Mark { get; }

      Person Author { get; }

      bool EditName(Person author, string newName);

      bool EditDescription(Person author, string newDescription);

      bool EditCriteria(Person author, string newCriteria);

      ILabwork Copy();
}