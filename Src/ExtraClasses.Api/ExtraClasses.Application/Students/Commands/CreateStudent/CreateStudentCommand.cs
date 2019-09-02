using MediatR;

namespace ExtraClasses.Application.Students.Commands.CreateStudent
{
    public class CreateStudentCommand : IRequest<Unit>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
    }
}
