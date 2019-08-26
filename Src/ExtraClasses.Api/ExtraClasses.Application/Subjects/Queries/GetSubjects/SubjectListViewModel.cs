using ExtraClasses.Application.Subjects.Queries.GetSubject;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraClasses.Application.Subjects.Queries.GetSubjects
{
    public class SubjectListViewModel
    {
        public IEnumerable<SubjectDto> Subjects { get; set; }
    }
}
