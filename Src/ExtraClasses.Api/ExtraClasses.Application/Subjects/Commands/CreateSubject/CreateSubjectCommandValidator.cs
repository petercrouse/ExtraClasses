using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraClasses.Application.Subjects.Commands.CreateSubject
{
    public class CreateSubjectCommandValidator: AbstractValidator<CreateSubjectCommand>
    {
        public CreateSubjectCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
