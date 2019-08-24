using ExtraClasses.Application.Teachers.Queries.GetTeacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraClasses.Application.Teachers.Queries.GetTeacherList
{
    public class TeacherListViewModel
    {
        public IEnumerable<TeacherLookupModel> Teachers { get; set; }
    }
}
