using AdventureWorks.Application.Interfaces;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.Tests
{
    public abstract class BaseTest
    {
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IAdventureWorksContext _context;

        protected BaseTest(IAdventureWorksContext context, IAuthenticatedUserService authenticatedUserService)
        {
            _context = context;
            _authenticatedUserService = authenticatedUserService;
        }
    }
}