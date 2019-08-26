using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraClasses.Application.Subjects.Queries.GetSubject
{
    public class GetSubjectQuery : IRequest<SubjectViewModel>
    {
        public int Id { get; set; }
    }
}
