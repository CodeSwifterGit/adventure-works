using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.HumanResources.Shift.Commands.DeleteShift
{
    public partial class DeleteShiftCommand : IRequest
    {
        public byte ShiftID { get; set; }
    }
}