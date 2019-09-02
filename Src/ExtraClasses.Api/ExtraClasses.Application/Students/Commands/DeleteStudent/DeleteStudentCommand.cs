using MediatR;

namespace ExtraClasses.Application.Students.Commands.DeleteStudent
{
    public class DeleteStudentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
