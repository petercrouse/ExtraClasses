using AutoMapper;
using AutoMapper.QueryableExtensions;
using ExtraClasses.Application.Bookings.Queries.GetBooking;
using ExtraClasses.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExtraClasses.Application.Bookings.Queries.GetBookingList
{
    public class GetBookingsQueryHandler : IRequestHandler<GetBookingListQuery, BookingListViewModel>
    {
        private readonly IExtraClassesDbContext _context;
        private readonly IMapper _mapper;

        public GetBookingsQueryHandler(IExtraClassesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BookingListViewModel> Handle(GetBookingListQuery request, CancellationToken cancellationToken)
        {
            return new BookingListViewModel
            {
                Bookings = await _context.Bookings.ProjectTo<BookingDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };
        }
    }
}
