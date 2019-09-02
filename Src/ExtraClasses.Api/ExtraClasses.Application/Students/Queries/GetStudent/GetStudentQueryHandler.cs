using ExtraClasses.Application.Exceptions;
using ExtraClasses.Domain.Entities;
using ExtraClasses.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ExtraClasses.Application.Students.Queries.GetStudent
{
    public class GetStudentQueryHandler : IRequestHandler<GetStudentQuery, StudentDto>
    {
        private readonly IExtraClassesDbContext _context;

        public GetStudentQueryHandler(IExtraClassesDbContext context)
        {
            _context = context;
        }

        public async Task<StudentDto> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Students.FindAsync(request.Id);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Student), request.Id);
            }

            return StudentDto.Create(entity);
        }
    }
}
