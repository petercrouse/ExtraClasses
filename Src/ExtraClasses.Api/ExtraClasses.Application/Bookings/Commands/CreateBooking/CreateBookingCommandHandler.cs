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

namespace ExtraClasses.Application.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, int>
    {
        private readonly IExtraClassesDbContext _context;

        public CreateBookingCommandHandler(IExtraClassesDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ExtraClasses.Where(c => c.ExtraClassId == request.ExtraClassId)
                                                    .Include(b => b.Bookings)
                                                    .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ExtraClass), request.ExtraClassId);
            }

            if (entity.Bookings.Any(b => b.StudentId == request.StudentId))
            {
                throw new DoubleBookingException(nameof(ExtraClass), request.ExtraClassId, request.StudentId);
            }

            if (entity.IsClassFull)
            {
                throw new ClassIsFullException(nameof(ExtraClass), request.ExtraClassId);
            }

            var booking = new Booking
            {
                ExtraClassId = entity.ExtraClassId,
                StudentId = request.StudentId,
                BookingPrice = entity.Price,
                Paid = false
            };

            _context.Bookings.Add(booking);

            if(entity.Bookings.Count == entity.Size)
            {
                entity.IsClassFull = true;
            }

            await _context.SaveChangesAsync(cancellationToken);

            return booking.BookingId;
        }
    }
}
