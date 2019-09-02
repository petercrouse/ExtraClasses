using MediatR;

namespace ExtraClasses.Application.Subjects.Commands.UpdateSubject
{
    public class UpdateSubjectCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
