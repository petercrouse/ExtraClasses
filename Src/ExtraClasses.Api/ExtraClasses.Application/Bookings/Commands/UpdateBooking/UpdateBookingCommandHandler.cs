using ExtraClasses.Application.Exceptions;
using ExtraClasses.Domain.Entities;
using ExtraClasses.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExtraClasses.Application.Bookings.Commands.UpdateBooking
{
    public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, Unit>
    {
        private readonly IExtraClassesDbContext _context;

        public UpdateBookingCommandHandler(IExtraClassesDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Bookings.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Booking), request.Id);
            }

            ExtraClass extraClass;

            if(entity.ExtraClassId != request.ExtraClassId)
            {
                extraClass = await _context.ExtraClasses.Where(c => c.ExtraClassId == request.ExtraClassId)
                                                        .Include(b => b.Bookings)
                                                        .SingleOrDefaultAsync(cancellationToken);

                if (extraClass == null)
                {
                    throw new NotFoundException(nameof(ExtraClass), request.ExtraClassId);
                }

                if (extraClass.Bookings.Any(b => b.StudentId == entity.StudentId))
                {
                    throw new DoubleBookingException(nameof(ExtraClass), request.ExtraClassId, entity.StudentId);
                }
            }           

            entity.BookingPrice = request.Price;
            entity.Paid = request.Paid;
            entity.ExtraClassId = request.ExtraClassId;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
