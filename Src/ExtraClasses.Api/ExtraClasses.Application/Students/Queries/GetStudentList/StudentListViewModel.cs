using ExtraClasses.Application.Students.Queries.GetStudent;
using System.Collections.Generic;

namespace ExtraClasses.Application.Students.Queries.GetStudentList
{
    public class StudentListViewModel
    {
        public IEnumerable<StudentDto> Students { get; set; }
    }
}
