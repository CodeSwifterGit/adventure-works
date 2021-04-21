using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Production.ScrapReason.Commands.DeleteScrapReason
{
    public partial class DeleteScrapReasonSetCommand : IRequest
    {
        public List<DeleteScrapReasonCommand> Commands { get; set; }
    }
}