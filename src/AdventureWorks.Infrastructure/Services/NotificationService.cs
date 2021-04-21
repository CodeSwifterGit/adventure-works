using System.Threading.Tasks;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Models;

namespace AdventureWorks.Infrastructure.Services
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(EmailMessage message)
        {
            return Task.CompletedTask;
        }
    }
}