using MediatR;

namespace ExtraClasses.Application.Students.Queries.GetStudent
{
    public class GetStudentQuery : IRequest<StudentDto>
    {
        public int Id { get; set; }
    }
}
