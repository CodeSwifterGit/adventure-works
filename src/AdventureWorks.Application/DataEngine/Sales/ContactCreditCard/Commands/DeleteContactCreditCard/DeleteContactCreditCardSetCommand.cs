using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Commands.DeleteContactCreditCard
{
    public partial class DeleteContactCreditCardSetCommand : IRequest
    {
        public List<DeleteContactCreditCardCommand> Commands { get; set; }
    }
}