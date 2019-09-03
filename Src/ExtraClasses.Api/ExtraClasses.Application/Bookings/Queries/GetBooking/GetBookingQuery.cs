using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraClasses.Application.Bookings.Queries.GetBooking
{
    public class GetBookingQuery : IRequest<BookingViewModel>
    {
        public int Id { get; set; }
    }
}
