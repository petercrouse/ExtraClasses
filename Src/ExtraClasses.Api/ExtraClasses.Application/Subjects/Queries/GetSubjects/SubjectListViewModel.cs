using ExtraClasses.Application.Subjects.Queries.GetSubject;
using System.Collections.Generic;

namespace ExtraClasses.Application.Subjects.Queries.GetSubjects
{
    public class SubjectListViewModel
    {
        public IEnumerable<SubjectDto> Subjects { get; set; }
    }
}
