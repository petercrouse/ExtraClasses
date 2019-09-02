using MediatR;

namespace ExtraClasses.Application.Students.Queries.GetStudentList
{
    public class GetStudentListQuery : IRequest<StudentListViewModel>
    {
    }
}
