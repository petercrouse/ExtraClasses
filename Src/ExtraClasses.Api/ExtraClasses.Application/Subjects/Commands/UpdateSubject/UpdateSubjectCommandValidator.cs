using FluentValidation;

namespace ExtraClasses.Application.Subjects.Commands.UpdateSubject
{
    public class UpdateSubjectCommandValidator: AbstractValidator<UpdateSubjectCommand>
    {
        public UpdateSubjectCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
