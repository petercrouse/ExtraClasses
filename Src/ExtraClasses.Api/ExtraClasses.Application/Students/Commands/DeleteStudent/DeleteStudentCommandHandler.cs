using ExtraClasses.Application.Exceptions;
using ExtraClasses.Domain.Entities;
using ExtraClasses.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExtraClasses.Application.Students.Commands.DeleteStudent
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, Unit>
    {
        private readonly IExtraClassesDbContext _context;

        public DeleteStudentCommandHandler(IExtraClassesDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Students.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Student), request.Id);
            }
           
            var hasBookings = _context.Bookings.Any(b => b.StudentId == entity.StudentId);
            if (hasBookings)
            {
                throw new DeleteFailureException(nameof(Student), request.Id, "There are exisiting bookings associated with this student");
            }

            _context.Students.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
