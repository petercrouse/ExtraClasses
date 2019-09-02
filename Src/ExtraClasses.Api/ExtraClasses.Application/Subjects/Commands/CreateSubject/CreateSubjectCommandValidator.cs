using FluentValidation;

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
