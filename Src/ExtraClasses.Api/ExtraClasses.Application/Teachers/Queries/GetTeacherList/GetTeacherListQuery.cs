using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraClasses.Application.Teachers.Queries.GetTeacherList
{
    public class GetTeacherListQuery : IRequest<TeacherListViewModel>
    {
    }
}
