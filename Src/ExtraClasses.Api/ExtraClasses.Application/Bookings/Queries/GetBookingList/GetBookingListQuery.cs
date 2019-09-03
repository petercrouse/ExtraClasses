using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraClasses.Application.Bookings.Queries.GetBookingList
{
    public class GetBookingListQuery : IRequest<BookingListViewModel>
    {
    }
}
