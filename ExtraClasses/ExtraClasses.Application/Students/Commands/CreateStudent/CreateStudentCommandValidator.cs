using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraClasses.Application.Students.Commands.CreateStudent
{
    public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentCommandValidator()
        {
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
