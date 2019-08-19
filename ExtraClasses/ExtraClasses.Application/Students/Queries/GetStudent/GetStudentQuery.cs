using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraClasses.Application.Students.Queries.GetStudent
{
    public class GetStudentQuery : IRequest<StudentDto>
    {
        public int Id { get; set; }
    }
}
