using MediatR;

namespace ExtraClasses.Application.Subjects.Commands.CreateSubject
{
    public class CreateSubjectCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
