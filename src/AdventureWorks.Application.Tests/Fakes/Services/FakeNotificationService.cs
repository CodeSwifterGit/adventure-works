using System.Threading.Tasks;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Models;

namespace AdventureWorks.Application.Tests.Fakes.Services
{
    public class FakeNotificationService : INotificationService
    {
        public Task SendAsync(EmailMessage message)
        {
            return Task.FromResult(true);
        }
    }
}