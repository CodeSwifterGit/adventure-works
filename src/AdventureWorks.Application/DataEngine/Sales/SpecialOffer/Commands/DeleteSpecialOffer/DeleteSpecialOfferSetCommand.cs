using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Sales.SpecialOffer.Commands.DeleteSpecialOffer
{
    public partial class DeleteSpecialOfferSetCommand : IRequest
    {
        public List<DeleteSpecialOfferCommand> Commands { get; set; }
    }
}