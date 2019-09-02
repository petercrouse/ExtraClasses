using ExtraClasses.Application.Exceptions;
using ExtraClasses.Domain.Entities;
using ExtraClasses.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ExtraClasses.Application.Teachers.Commands.UpdateTeacher
{
    public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand, Unit>
    {
        private readonly IExtraClassesDbContext _context;

        public UpdateTeacherCommandHandler(IExtraClassesDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Teachers.FindAsync(request.Id);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Teacher), request.Id);
            }

            entity.LastName = request.LastName;
            entity.FirstName = request.FirstName;
            entity.Email = request.Email;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
