using Itmo.ObjectOrientedProgramming.Lab2.IBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Objects;

public class Lecture : ILecture
{
    public Guid Id { get; private set; }

    public Guid? IdCopy { get; private set; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public string Content { get; private set; }

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
            Description = newDescription;
            return true;
        }

        return false;
    }

    public bool EditContent(Person author, string newContent)
    {
        if (CheckCorrectAuthor(author))
        {
            Content = newContent;
            return true;
        }

        return false;
    }

    public Lecture(string name, string description, string content, Person author)
    {
        Id = Guid.NewGuid();
        IdCopy = null;
        Name = name;
        Description = description;
        Content = content;
        Author = author;
    }

    private Lecture(Guid? idCopy, string name, string description, string content, Person author)
    {
        Id = Guid.NewGuid();
        IdCopy = idCopy;
        Name = name;
        Description = description;
        Content = content;
        Author = author;
    }

    public ILecture Copy()
    {
        return new Lecture(
            Id,
            Name,
            Description,
            Content,
            Author.Copy());
    }

    private bool CheckCorrectAuthor(Person author)
    {
        return Author == author;
    }

    public static BuilderLecture Builder => new BuilderLecture();

    public class BuilderLecture : IBuilderLecture
    {
        public string? Name { get; private set; }

        public string? Description { get; private set; }

        public string? Content { get; private set; }

        public Person? Author { get; private set; }

        public IBuilderLecture AddName(string name)
        {
            Name = name;
            return this;
        }

        public IBuilderLecture AddDescription(string description)
        {
            Description = description;
            return this;
        }

        public IBuilderLecture AddContent(string content)
        {
            Content = content;
            return this;
        }

        public IBuilderLecture AddAuthor(Person author)
        {
            Author = author;
            return this;
        }

        public ILecture Build()
        {
            ILecture lecture = new Lecture(
                Name ?? throw new ArgumentNullException(),
                Description ?? throw new ArgumentNullException(),
                Content ?? throw new ArgumentNullException(),
                Author ?? throw new ArgumentNullException());
            Clear();
            return lecture;
        }

        private void Clear()
        {
            Name = null;
            Description = null;
            Content = null;
            Author = null;
        }
    }
}