using AutoMapper;
using AutoMapper.QueryableExtensions;
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

namespace ExtraClasses.Application.Bookings.Queries.GetBooking
{
    public class GetBookingQueryHandler : IRequestHandler<GetBookingQuery, BookingViewModel>
    {
        private readonly IExtraClassesDbContext _context;
        private readonly IMapper _mapper;

        public GetBookingQueryHandler(IExtraClassesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BookingViewModel> Handle(GetBookingQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Bookings.Where(b => b.BookingId == request.Id)
                                                 .Include(c => c.ExtraClass)
                                                 .Include(s => s.Student)
                                                 .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Booking), request.Id);
            }

            return new BookingViewModel
            {
                Booking = _mapper.Map<BookingDto>(entity)
            };
        }
    }
}
