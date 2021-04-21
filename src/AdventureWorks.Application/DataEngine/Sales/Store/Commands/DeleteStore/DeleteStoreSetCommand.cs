using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Sales.Store.Commands.DeleteStore
{
    public partial class DeleteStoreSetCommand : IRequest
    {
        public List<DeleteStoreCommand> Commands { get; set; }
    }
}