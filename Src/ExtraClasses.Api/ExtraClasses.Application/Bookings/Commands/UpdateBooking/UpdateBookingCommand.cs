using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraClasses.Application.Bookings.Commands.UpdateBooking
{
    public class UpdateBookingCommand: IRequest<Unit>
    {
        public int Id { get; set; }
        public int ExtraClassId { get; set; }
        public bool Paid { get; set; }
        public double Price { get; set; }
    }
}
