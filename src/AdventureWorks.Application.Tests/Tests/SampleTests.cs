using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Models;
using AdventureWorks.Domain;
using Microsoft.Extensions.Logging;

namespace AdventureWorks.Application.Tests.Tests
{
    public class CodeFormattingTests : BaseTest
    {
        private readonly ILogger<CodeFormattingTests> _logger;
        private readonly ServerConfiguration _serverConfiguration;

        public CodeFormattingTests(IAdventureWorksContext context,
            IAuthenticatedUserService authenticatedUserService,
            ServerConfiguration serverConfiguration, ILogger<CodeFormattingTests> logger) :
            base(context, authenticatedUserService)
        {
            _serverConfiguration = serverConfiguration;
            _logger = logger;
        }
    }
}