using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraClasses.Application.Teachers.Commands.UpdateTeacher
{
    public class UpdateTeacherCommandValidator : AbstractValidator<UpdateTeacherCommand>
    {
        public UpdateTeacherCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
