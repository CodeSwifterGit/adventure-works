using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Production.UnitMeasure.Commands.DeleteUnitMeasure
{
    public partial class DeleteUnitMeasureSetCommand : IRequest
    {
        public List<DeleteUnitMeasureCommand> Commands { get; set; }
    }
}