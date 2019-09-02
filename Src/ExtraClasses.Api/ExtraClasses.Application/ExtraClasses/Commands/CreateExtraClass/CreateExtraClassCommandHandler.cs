using ExtraClasses.Application.Exceptions;
using ExtraClasses.Application.Extensions;
using ExtraClasses.Domain.Entities;
using ExtraClasses.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExtraClasses.Application.ExtraClasses.Commands.CreateExtraClass
{
    public class CreateExtraClassCommandHandler : IRequestHandler<CreateExtraClassCommand, int>
    {
        private readonly IExtraClassesDbContext _context;

        public CreateExtraClassCommandHandler(IExtraClassesDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateExtraClassCommand request, CancellationToken cancellationToken)
        {
            var teacher = await _context.Teachers.Where(t => t.TeacherId == request.TeacherId)
                                                 .Include(ts => ts.TeachingSubjects)
                                                 .FirstOrDefaultAsync(cancellationToken);

            if (teacher == null)
            {
                throw new NotFoundException(nameof(Teacher), request.TeacherId);
            }          

            if (!teacher.TeachSubject(request.SubjectId))
            {
                throw new TeacherDoesNotTeachSubjectException(teacher.TeacherId, request.SubjectId);
            }

            var entity = new ExtraClass
            {
                Name = request.Name,
                Date = request.Date,
                Duration = request.Duration,
                IsClassFull = false,
                Size = request.Size,
                SubjectId = request.SubjectId,
                TeacherId = request.TeacherId,
                Price = request.Price,
            };

            _context.ExtraClasses.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.ExtraClassId;
        }
    }
}
