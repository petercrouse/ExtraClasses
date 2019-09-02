using System.Collections.Generic;

namespace ExtraClasses.Application.Students.Queries.GetStudentList
{
    public class StudentListViewModel
    {
        public IEnumerable<StudentLookupModel> Students { get; set; }
    }
}
