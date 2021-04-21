using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Person.Address.Commands.DeleteAddress
{
    public partial class DeleteAddressSetCommand : IRequest
    {
        public List<DeleteAddressCommand> Commands { get; set; }
    }
}