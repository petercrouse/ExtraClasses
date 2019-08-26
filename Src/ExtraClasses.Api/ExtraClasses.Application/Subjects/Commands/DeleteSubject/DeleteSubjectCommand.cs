using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraClasses.Application.Subjects.Commands.DeleteSubject
{
    public class DeleteSubjectCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
