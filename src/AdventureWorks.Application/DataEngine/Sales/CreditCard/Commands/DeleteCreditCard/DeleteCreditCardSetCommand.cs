using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Sales.CreditCard.Commands.DeleteCreditCard
{
    public partial class DeleteCreditCardSetCommand : IRequest
    {
        public List<DeleteCreditCardCommand> Commands { get; set; }
    }
}