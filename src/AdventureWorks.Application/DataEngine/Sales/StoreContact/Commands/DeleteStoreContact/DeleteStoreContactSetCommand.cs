using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Sales.StoreContact.Commands.DeleteStoreContact
{
    public partial class DeleteStoreContactSetCommand : IRequest
    {
        public List<DeleteStoreContactCommand> Commands { get; set; }
    }
}