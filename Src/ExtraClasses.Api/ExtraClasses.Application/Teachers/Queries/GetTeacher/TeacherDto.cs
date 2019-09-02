using ExtraClasses.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace ExtraClasses.Application.Teachers.Queries.GetTeacher
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }

        public static Expression<Func<Teacher, TeacherDto>> Projection
        {
            get
            {
                return teacher => new TeacherDto
                {
                    Id = teacher.TeacherId,
                    LastName = teacher.LastName,
                    FirstName = teacher.FirstName,
                    Email = teacher.FirstName
                };
            }
        }

        public static TeacherDto Create(Teacher teacher)
        {
            return Projection.Compile().Invoke(teacher);
        }
    }
}
