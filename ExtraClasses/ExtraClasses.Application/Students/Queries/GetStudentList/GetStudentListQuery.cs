using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraClasses.Application.Students.Queries.GetStudentList
{
    public class GetStudentListQuery : IRequest<StudentListViewModel>
    {
    }
}
