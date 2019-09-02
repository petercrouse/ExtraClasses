using MediatR;

namespace ExtraClasses.Application.Teachers.Commands.CreateTeacher
{
    public class CreateTeacherCommand : IRequest<Unit>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
    }
}
