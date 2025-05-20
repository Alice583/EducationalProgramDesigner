using Itmo.ObjectOrientedProgramming.Lab2.IBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Objects;

public class Labwork : ILabwork
{
    public Guid Id { get; private set; }

    public Guid? IdCopy { get; private set; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public string Criteries { get; private set; }

    public int Mark { get; private set; }

    public Person Author { get; private set; }

    public bool EditName(Person author, string newName)
    {
        if (CheckCorrectAuthor(author))
        {
            Name = newName;
            return true;
        }

        return false;
    }

    public bool EditDescription(Person author, string newDescription)
    {
        if (CheckCorrectAuthor(author))
        {
            Criteries = newDescription;
            return true;
        }

        return false;
    }

    public bool EditCriteria(Person author, string newCriteria)
    {
        if (CheckCorrectAuthor(author))
        {
            Criteries = newCriteria;
            return true;
        }

        return false;
    }

    public Labwork(string name, string description, string criteries, int mark, Person author)
    {
        Id = Guid.NewGuid();
        IdCopy = null;
        Name = name;
        Description = description;
        Criteries = criteries;
        Mark = mark;
        Author = author;
    }

    private Labwork(Guid? idCopy, string name, string description, string criteries, int mark, Person author)
    {
        Id = Guid.NewGuid();
        IdCopy = idCopy;
        Name = name;
        Description = description;
        Criteries = criteries;
        Mark = mark;
        Author = author;
    }

    public ILabwork Copy()
    {
        return new Labwork(
            Id,
            Name,
            Description,
            Criteries,
            Mark,
            Author.Copy());
    }

    private bool CheckCorrectAuthor(Person author)
    {
        return Author == author;
    }

    public static BuilderLabwork Builder => new Labwork.BuilderLabwork();

    public class BuilderLabwork : IBuilderLabwork
    {
        public string? Name { get; private set; }

        public string? Description { get; private set; }

        public string? Criteries { get; private set; }

        public int? Mark { get; private set; }

        public Person? Author { get; private set; }

        public IBuilderLabwork AddName(string name)
        {
            Name = name;
            return this;
        }

        public IBuilderLabwork AddDescription(string description)
        {
            Description = description;
            return this;
        }

        public IBuilderLabwork AddCriteries(string criteries)
        {
            Criteries = criteries;
            return this;
        }

        public IBuilderLabwork AddMark(int mark)
        {
            Mark = mark;
            return this;
        }

        public IBuilderLabwork AddAuthor(Person author)
        {
            Author = author;
            return this;
        }

        public ILabwork Build()
        {
            ILabwork labwork = new Labwork(
                Name ?? throw new ArgumentNullException(),
                Description ?? throw new ArgumentNullException(),
                Criteries ?? throw new ArgumentNullException(),
                Mark ?? throw new ArgumentNullException(),
                Author ?? throw new ArgumentNullException());
            Clear();
            return labwork;
        }

        private void Clear()
        {
            Name = null;
            Description = null;
            Criteries = null;
            Mark = null;
            Author = null;
        }
    }
}