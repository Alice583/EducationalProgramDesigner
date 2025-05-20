using Itmo.ObjectOrientedProgramming.Lab2.IBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Objects;

public class EducationalProgram : IEducationalProgram
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public Dictionary<int, IList<ISubject>> Subjects { get; private set; }

    public Person Author { get; private set; }

    public EducationalProgram(string name, Dictionary<int, IList<ISubject>> subjects, Person author)
    {
        Id = Guid.NewGuid();
        Name = name;
        Subjects = subjects;
        Author = author;
    }

    public static BuilderEducationalProgram Builder => new EducationalProgram.BuilderEducationalProgram();

    public class BuilderEducationalProgram : IBuilderEducationalProgram
    {
        public string? Name { get; private set; }

        private Dictionary<int, IList<ISubject>>? _subjects;

        public Person? Author { get; private set; }

        public IBuilderEducationalProgram AddName(string name)
        {
            Name = name;
            return this;
        }

        public IBuilderEducationalProgram AddSubject(int semester, ISubject subject)
        {
            _subjects ??= new Dictionary<int, IList<ISubject>>();

            if (!_subjects.ContainsKey(semester))
            {
                _subjects[semester] = new List<ISubject>();
            }

            _subjects[semester].Add(subject);
            return this;
        }

        public IBuilderEducationalProgram AddAuthor(Person author)
        {
            Author = author;
            return this;
        }

        public IEducationalProgram Build()
        {
            IEducationalProgram educationalProgram = new EducationalProgram(
                Name ?? throw new ArgumentNullException(),
                _subjects ?? throw new ArgumentNullException(),
                Author ?? throw new ArgumentNullException());
            Clear();
            return educationalProgram;
        }

        private void Clear()
        {
            Name = null;
            if (_subjects != null)
            {
                _subjects.Clear();
            }

            Author = null;
        }
    }
}