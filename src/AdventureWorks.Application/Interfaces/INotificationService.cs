using System.Threading.Tasks;
using AdventureWorks.Application.Models;

namespace AdventureWorks.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(EmailMessage message);
    }
}