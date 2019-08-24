using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraClasses.Application.Teachers.Queries.GetTeacher
{
    public class GetTeacherQuery : IRequest<TeacherDto>
    {
        public int Id { get; set; }
    }
}
