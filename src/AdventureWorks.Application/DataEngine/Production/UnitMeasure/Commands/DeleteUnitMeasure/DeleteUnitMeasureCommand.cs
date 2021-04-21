using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.UnitMeasure.Commands.DeleteUnitMeasure
{
    public partial class DeleteUnitMeasureCommand : IRequest
    {
        public string UnitMeasureCode { get; set; }
    }
}