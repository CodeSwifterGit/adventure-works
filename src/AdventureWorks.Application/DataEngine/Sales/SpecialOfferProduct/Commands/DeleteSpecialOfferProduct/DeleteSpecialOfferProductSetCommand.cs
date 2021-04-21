using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Sales.SpecialOfferProduct.Commands.DeleteSpecialOfferProduct
{
    public partial class DeleteSpecialOfferProductSetCommand : IRequest
    {
        public List<DeleteSpecialOfferProductCommand> Commands { get; set; }
    }
}