using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Person.StateProvince.Commands.DeleteStateProvince
{
    public partial class DeleteStateProvinceSetCommand : IRequest
    {
        public List<DeleteStateProvinceCommand> Commands { get; set; }
    }
}