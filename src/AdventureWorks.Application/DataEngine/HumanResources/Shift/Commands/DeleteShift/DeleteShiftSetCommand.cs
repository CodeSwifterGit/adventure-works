using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.HumanResources.Shift.Commands.DeleteShift
{
    public partial class DeleteShiftSetCommand : IRequest
    {
        public List<DeleteShiftCommand> Commands { get; set; }
    }
}