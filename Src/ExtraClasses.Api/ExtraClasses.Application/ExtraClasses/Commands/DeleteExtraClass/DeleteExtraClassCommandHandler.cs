using ExtraClasses.Application.Exceptions;
using ExtraClasses.Domain.Entities;
using ExtraClasses.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExtraClasses.Application.ExtraClasses.Commands.DeleteExtraClass
{
    public class DeleteExtraClassCommandHandler : IRequestHandler<DeleteExtraClassCommand, Unit>
    {
        private readonly IExtraClassesDbContext _context;

        public DeleteExtraClassCommandHandler(IExtraClassesDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteExtraClassCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ExtraClasses.Where(c => c.ExtraClassId == request.Id)
                                                    .Include(b => b.Bookings)
                                                    .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ExtraClass), request.Id);
            }

            var hasBookings = _context.Bookings.Any(b => b.ExtraClassId == entity.ExtraClassId);
            if (hasBookings)
            {
                throw new DeleteFailureException(nameof(Student), request.Id, "There are exisiting bookings associated with this class");
            }

            //ToDo: decide on the best way to delete a class
            _context.ExtraClasses.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
