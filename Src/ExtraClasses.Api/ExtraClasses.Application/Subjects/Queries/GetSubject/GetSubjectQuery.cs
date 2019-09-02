using MediatR;

namespace ExtraClasses.Application.Subjects.Queries.GetSubject
{
    public class GetSubjectQuery : IRequest<SubjectViewModel>
    {
        public int Id { get; set; }
    }
}
