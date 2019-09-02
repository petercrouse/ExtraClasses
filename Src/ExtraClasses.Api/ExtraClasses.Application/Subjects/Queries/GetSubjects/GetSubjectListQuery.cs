using MediatR;

namespace ExtraClasses.Application.Subjects.Queries.GetSubjects
{
    public class GetSubjectListQuery : IRequest<SubjectListViewModel>
    {
    }
}
