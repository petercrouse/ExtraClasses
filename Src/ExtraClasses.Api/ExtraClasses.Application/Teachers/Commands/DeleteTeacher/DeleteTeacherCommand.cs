using MediatR;

namespace ExtraClasses.Application.Teachers.Commands.DeleteTeacher
{
    public class DeleteTeacherCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
