using ExtraClasses.Application.Exceptions;
using ExtraClasses.Domain.Entities;
using ExtraClasses.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ExtraClasses.Application.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Unit>
    {
        private readonly IExtraClassesDbContext _context;

        public UpdateStudentCommandHandler(IExtraClassesDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Students.FindAsync(request.Id);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Student), request.Id);
            }

            entity.LastName = request.LastName;
            entity.FirstName = request.FirstName;
            entity.Email = request.Email;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
