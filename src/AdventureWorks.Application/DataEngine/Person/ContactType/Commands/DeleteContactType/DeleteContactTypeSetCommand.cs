using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Person.ContactType.Commands.DeleteContactType
{
    public partial class DeleteContactTypeSetCommand : IRequest
    {
        public List<DeleteContactTypeCommand> Commands { get; set; }
    }
}