using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraClasses.Application.Subjects.Queries.GetSubjects
{
    public class GetSubjectListQuery : IRequest<SubjectListViewModel>
    {
    }
}
