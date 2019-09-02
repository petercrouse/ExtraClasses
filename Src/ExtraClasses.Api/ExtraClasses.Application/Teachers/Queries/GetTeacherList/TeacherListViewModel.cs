using System.Collections.Generic;

namespace ExtraClasses.Application.Teachers.Queries.GetTeacherList
{
    public class TeacherListViewModel
    {
        public IEnumerable<TeacherLookupModel> Teachers { get; set; }
    }
}
