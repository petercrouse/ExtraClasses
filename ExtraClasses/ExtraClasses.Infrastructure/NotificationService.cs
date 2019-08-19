using ExtraClasses.Application.Interfaces;
using ExtraClasses.Application.Notifications.Models;
using System;
using System.Threading.Tasks;

namespace ExtraClasses.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(Message message)
        {
            return Task.CompletedTask;
        }
    }
}
