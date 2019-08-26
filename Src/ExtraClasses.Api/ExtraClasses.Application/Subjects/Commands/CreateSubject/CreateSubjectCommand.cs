using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraClasses.Application.Subjects.Commands.CreateSubject
{
    public class CreateSubjectCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
