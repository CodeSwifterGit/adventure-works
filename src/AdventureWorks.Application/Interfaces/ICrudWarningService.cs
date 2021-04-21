using System.Threading.Tasks;
using AdventureWorks.Application.Models;

namespace AdventureWorks.Application.Interfaces
{
    public interface ICrudWarningService
    {
        Task SendAsync(CrudWarningMessage message);
    }
}