using MediatR;

namespace ExtraClasses.Application.Students.Queries.GetStudent
{
    public class GetStudentQuery : IRequest<StudentViewModel>
    {
        public int Id { get; set; }
    }
}
