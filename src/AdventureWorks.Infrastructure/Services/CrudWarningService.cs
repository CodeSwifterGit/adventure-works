using System.Threading.Tasks;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Models;
using AdventureWorks.Domain;

namespace AdventureWorks.Infrastructure.Services
{
    public class CrudWarningService : ICrudWarningService
    {
        private readonly IAdventureWorksContext _ctx;
        private readonly INotificationService _notificationService;

        public CrudWarningService(INotificationService notificationService, IAdventureWorksContext ctx)
        {
            _notificationService = notificationService;
            _ctx = ctx;
        }

        public Task SendAsync(CrudWarningMessage message)
        {
            // Here, we need to decide, who will receive warnings about CRUD updates

            return Task.FromResult(true);
        }
    }
}