using ExtraClasses.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace ExtraClasses.Application.Students.Queries.GetStudent
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }

        public static Expression<Func<Student, StudentDto>> Projection
        {
            get
            {
                return student => new StudentDto
                {
                    Id = student.StudentId,
                    LastName = student.LastName,
                    FirstName = student.FirstName,
                    Email = student.FirstName
                };
            }
        }

        public static StudentDto Create(Student student)
        {
            return Projection.Compile().Invoke(student);
        }
    }
}
