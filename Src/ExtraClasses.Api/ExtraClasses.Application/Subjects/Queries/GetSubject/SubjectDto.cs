using ExtraClasses.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace ExtraClasses.Application.Subjects.Queries.GetSubject
{
    public class SubjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static Expression<Func<Subject, SubjectDto>> Projection
        {
            get
            {
                return subject => new SubjectDto
                {
                    Id = subject.SubjectId,
                    Name = subject.Name
                };
            }
        }

        public static SubjectDto Create(Subject subject)
        {
            return Projection.Compile().Invoke(subject);
        }
    }
}
