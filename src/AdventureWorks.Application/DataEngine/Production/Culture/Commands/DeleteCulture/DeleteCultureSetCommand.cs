using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Production.Culture.Commands.DeleteCulture
{
    public partial class DeleteCultureSetCommand : IRequest
    {
        public List<DeleteCultureCommand> Commands { get; set; }
    }
}