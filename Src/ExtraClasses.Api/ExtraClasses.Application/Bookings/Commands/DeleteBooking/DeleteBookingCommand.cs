using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraClasses.Application.Bookings.Commands.DeleteBooking
{
    public class DeleteBookingCommand: IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
