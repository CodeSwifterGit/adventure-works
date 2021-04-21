using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Person.Contact.Commands.DeleteContact
{
    public partial class DeleteContactSetCommand : IRequest
    {
        public List<DeleteContactCommand> Commands { get; set; }
    }
}