using System;
using MediatR;
using AdventureWorks.Application.DataEngine.HumanResources.Shift.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.HumanResources.Shift.Queries.GetShifts;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.HumanResources.Shift.Queries.GetShiftDetail
{
    public partial class GetShiftDetailQuery : IRequest<ShiftLookupModel>
    {
        public byte ShiftID { get; set; }
    }
}
