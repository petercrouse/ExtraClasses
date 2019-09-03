using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraClasses.Application.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommand: IRequest<int>
    {
        public int ExtraClassId { get; set; }
        public int StudentId { get; set; }
    }
}
