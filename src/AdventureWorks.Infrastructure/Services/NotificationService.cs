using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Models;

namespace AdventureWorks.Infrastructure.Services
{
    public class NotificationService : INotificationService
    {
        public async Task SendAsync(string title, string message, CancellationToken cancellationToken)
        {
        }
    }
}