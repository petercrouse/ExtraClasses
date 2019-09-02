using ExtraClasses.Application.Exceptions;
using ExtraClasses.Domain.Entities;
using ExtraClasses.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ExtraClasses.Application.Subjects.Queries.GetSubject
{
    public class GetSubjectQueryHandler : IRequestHandler<GetSubjectQuery, SubjectViewModel>
    {
        private readonly IExtraClassesDbContext _context;

        public GetSubjectQueryHandler(IExtraClassesDbContext context)
        {
            _context = context;
        }

        public async Task<SubjectViewModel> Handle(GetSubjectQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Subjects.FindAsync(request.Id);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Subject), request.Id);
            }

            return new SubjectViewModel
            {
                Subject = SubjectDto.Create(entity)
            };               
        }
    }
}
