using ExtraClasses.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace ExtraClasses.Application.ExtraClasses.Commands.DeleteExtraClass
{
    public class ExtraClassDeleted : INotification
    {
        public IEnumerable<Booking> Bookings { get; set; }      
    }
}