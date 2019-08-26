using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraClasses.Application.ExtraClasses.Commands.DeleteExtraClass
{
    public class DeleteExtraClassCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
