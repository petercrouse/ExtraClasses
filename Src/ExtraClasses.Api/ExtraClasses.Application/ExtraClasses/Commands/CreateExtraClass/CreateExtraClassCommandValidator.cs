using ExtraClasses.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraClasses.Application.ExtraClasses.Commands.CreateExtraClass
{
    public class CreateExtraClassCommandValidator : AbstractValidator<CreateExtraClassCommand>
    {
        public CreateExtraClassCommandValidator(IDateTime dateTime)
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Date).GreaterThanOrEqualTo(dateTime.Now);
            RuleFor(x => x.Duration).GreaterThanOrEqualTo(new TimeSpan(0, 30, 0));
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
            RuleFor(x => x.SubjectId).NotNull();
        }
    }
}
