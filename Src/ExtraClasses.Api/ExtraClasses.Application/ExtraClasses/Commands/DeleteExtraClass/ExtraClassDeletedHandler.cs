using ExtraClasses.Application.Interfaces;
using ExtraClasses.Application.Notifications.Models;
using ExtraClasses.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExtraClasses.Application.ExtraClasses.Commands.DeleteExtraClass
{
    public class ExtraClassDeletedHandler : INotificationHandler<ExtraClassDeleted>
    {
        private readonly INotificationService _notificationService;

        public ExtraClassDeletedHandler(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task Handle(ExtraClassDeleted notification, CancellationToken cancellationToken)
        {
            var bookings = notification.Bookings.ToList();

            var message = new Message()
            {
                From = "CrouseMath",
                BCC = CreateBCCRecipients(bookings),
                Subject = "Account created",
                Body = $"Hello,\n" +
                $" We regret to inform you that the class {bookings.FirstOrDefault().ExtraClass.Name} has been cancelled\n"
            };

            await _notificationService.SendAsync(message);

        }

        private string CreateBCCRecipients(List<Booking> bookings)
        {
            string bccRecipients = "";

            bookings.ForEach(x => bccRecipients += $"{x.Student.Email};");

            return bccRecipients;
        }
    }
}
