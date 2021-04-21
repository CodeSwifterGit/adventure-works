using System.Threading.Tasks;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Models;

namespace AdventureWorks.Application.Tests.Fakes.Services
{
    public class FakeCrudWarningService : ICrudWarningService
    {
        public Task SendAsync(CrudWarningMessage message)
        {
            return Task.FromResult(true);
        }
    }
}