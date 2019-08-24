using ExtraClasses.Application.Notifications.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExtraClasses.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(Message message);
    }
}
