using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Person.AddressType.Commands.DeleteAddressType
{
    public partial class DeleteAddressTypeSetCommand : IRequest
    {
        public List<DeleteAddressTypeCommand> Commands { get; set; }
    }
}