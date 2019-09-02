using MediatR;

namespace ExtraClasses.Application.Subjects.Commands.DeleteSubject
{
    public class DeleteSubjectCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
