using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Models;

namespace AdventureWorks.Application.Tests.Fakes.Services
{
    public class FakeNotificationService : INotificationService
    {
        public async Task SendAsync(string title, string message, CancellationToken cancellationToken)
        {
        }
    }
}