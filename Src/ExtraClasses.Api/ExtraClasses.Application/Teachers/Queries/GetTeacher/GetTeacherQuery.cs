using MediatR;

namespace ExtraClasses.Application.Teachers.Queries.GetTeacher
{
    public class GetTeacherQuery : IRequest<TeacherViewModel>
    {
        public int Id { get; set; }
    }
}
