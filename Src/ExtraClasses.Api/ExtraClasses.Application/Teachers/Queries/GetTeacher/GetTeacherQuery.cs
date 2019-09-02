using MediatR;

namespace ExtraClasses.Application.Teachers.Queries.GetTeacher
{
    public class GetTeacherQuery : IRequest<TeacherDto>
    {
        public int Id { get; set; }
    }
}
