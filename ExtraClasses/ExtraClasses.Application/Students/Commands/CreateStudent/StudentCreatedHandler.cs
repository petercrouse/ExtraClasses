using ExtraClasses.Application.Interfaces;
using ExtraClasses.Application.Notifications.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExtraClasses.Application.Students.Commands.CreateStudent
{
    public class StudentCreatedHandler : INotificationHandler<StudentCreated>
    {
        private readonly INotificationService _notification;

        public StudentCreatedHandler(INotificationService notification)
        {
            _notification = notification;
        }

        public async Task Handle(StudentCreated notification, CancellationToken cancellationToken)
        {
            var message = new Message()
            {
                From = "CrouseMath",
                To = notification.Email,
                Subject = "Account created",
                Body = $"Hello {notification.FirstName} {notification.LastName},\n" +
                $" Welcome to CrouseMath."
            };

            await _notification.SendAsync(message);
        }
    }
}
