using Itmo.ObjectOrientedProgramming.Lab2.IBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Objects;

public class Subject : ISubject
{
    public Guid Id { get; private set; }

    public Guid? IdCopy { get; private set; }

    public int? Exam { get; private set; }

    public int? Credit { get; private set; }

    public IList<ILecture> Lectures { get; private set; }

    public IList<ILabwork> Labworks { get; private set; }

    public string Name { get; private set; }

    public Person Author { get; private set; }

    private Subject(
        Guid id,
        Guid? idCopy,
        string name,
        IList<ILecture> lectures,
        IList<ILabwork> labworks,
        Person author,
        int? exam = null,
        int? credit = null)
    {
        Id = id;
        IdCopy = idCopy;
        Name = name;
        Lectures = lectures;
        Labworks = labworks;
        Author = author;
        Exam = exam;
        Credit = credit;
    }

    public ISubject Copy()
    {
        return new Subject(
            Guid.NewGuid(),
            Id,
            Name,
            Lectures.Select(lecture => lecture.Copy()).ToList(),
            Labworks.Select(lab => lab.Copy()).ToList(),
            Author.Copy(),
            Exam,
            Credit);
    }

    public bool CheckCorrectAuthor(Person author)
    {
        return Author == author;
    }

    public static BuilderSubject Builder => new BuilderSubject();

    public class BuilderSubject : IBuilderSubject
    {
        public IList<ILecture> Lectures { get; private set; } = new List<ILecture>();

        public IList<ILabwork> Labworks { get; private set; } = new List<ILabwork>();

        public Guid? Id { get; private set; }

        public string? Name { get; private set; }

        public Person? Author { get; private set; }

        public int? Exam { get; private set; }

        public int? Credit { get; private set; }

        public IBuilderSubject AddName(string name)
        {
            Name = name;
            return this;
        }

        public IBuilderSubject AddLecture(ILecture lecture)
        {
            Lectures.Add(lecture);
            return this;
        }

        public IBuilderSubject AddLabwork(ILabwork labwork)
        {
            Labworks.Add(labwork);
            return this;
        }

        public IBuilderSubject AddCredit(int creditMark)
        {
            Credit = creditMark;
            return this;
        }

        public IBuilderSubject AddAuthor(Person author)
        {
            Author = author;
            return this;
        }

        public IBuilderSubject AddExam(int examMark)
        {
            Exam = examMark;
            return this;
        }

        public IBuilderSubject AddId(Guid id)
        {
            Id = id;
            return this;
        }

        public ISubject? BuildWithId()
        {
            if (Id == null)
            {
                return null;
            }

            if (!CheckLabworkPoints())
            {
                return null;
            }

            if ((Exam is null && Credit is null) || (Exam is not null && Credit is not null))
            {
                return null;
            }

            if (Exam is null)
            {
                ISubject subject = new Subject(
                    Id ?? throw new ArgumentException(),
                    null,
                    Name ?? throw new ArgumentNullException(),
                    Lectures ?? throw new ArgumentNullException(),
                    Labworks ?? throw new ArgumentNullException(),
                    Author ?? throw new ArgumentNullException(),
                    null,
                    Credit ?? throw new ArgumentNullException());
                Clear();
                return subject;
            }
            else
            {
                ISubject subject = new Subject(
                    Id ?? throw new ArgumentException(),
                    null,
                    Name ?? throw new ArgumentNullException(),
                    Lectures ?? throw new ArgumentNullException(),
                    Labworks ?? throw new ArgumentNullException(),
                    Author ?? throw new ArgumentNullException(),
                    Exam,
                    null);
                Clear();
                return subject;
            }
        }

        public ISubject? BuildWithoutId()
        {
            if (Id != null)
            {
                return null;
            }

            if (!CheckLabworkPoints())
            {
                return null;
            }

            if ((Exam is null && Credit is null) || (Exam is not null && Credit is not null))
            {
                return null;
            }

            if (Exam is null)
            {
                ISubject subject = new Subject(
                    Guid.NewGuid(),
                    null,
                    Name ?? throw new ArgumentNullException(),
                    Lectures ?? throw new ArgumentNullException(),
                    Labworks ?? throw new ArgumentNullException(),
                    Author ?? throw new ArgumentNullException(),
                    null,
                    Credit ?? throw new ArgumentNullException());
                Clear();
                return subject;
            }
            else
            {
                ISubject subject = new Subject(
                    Guid.NewGuid(),
                    null,
                    Name ?? throw new ArgumentNullException(),
                    Lectures ?? throw new ArgumentNullException(),
                    Labworks ?? throw new ArgumentNullException(),
                    Author ?? throw new ArgumentNullException(),
                    Exam,
                    null);
                Clear();
                return subject;
            }
        }

        private void Clear()
        {
            Lectures.Clear();
            Labworks.Clear();
            Name = null;
            Author = null;
            Exam = null;
            Credit = null;
        }

        private bool CheckLabworkPoints()
        {
            int sumPoints = 0;
            foreach (ILabwork labwork in Labworks)
            {
                sumPoints += labwork.Mark;
            }

            if (Exam != null)
            {
                return sumPoints + Exam == 100;
            }
            else
            {
                return sumPoints == 100;
            }
        }
    }
}