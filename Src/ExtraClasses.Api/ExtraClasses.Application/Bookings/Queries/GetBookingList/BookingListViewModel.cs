using ExtraClasses.Application.Bookings.Queries.GetBooking;
using System.Collections.Generic;

namespace ExtraClasses.Application.Bookings.Queries.GetBookingList
{
    public class BookingListViewModel
    {
        public IEnumerable<BookingDto> Bookings { get; set; }
    }
}