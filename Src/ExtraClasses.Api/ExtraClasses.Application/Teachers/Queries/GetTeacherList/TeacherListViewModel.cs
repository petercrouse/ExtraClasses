using ExtraClasses.Application.Teachers.Queries.GetTeacher;
using System.Collections.Generic;

namespace ExtraClasses.Application.Teachers.Queries.GetTeacherList
{
    public class TeacherListViewModel
    {
        public IEnumerable<TeacherDto> Teachers { get; set; }
    }
}
