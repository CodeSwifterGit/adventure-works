using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Production.UnitMeasure.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Production.UnitMeasure.Queries.GetUnitMeasures;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.UnitMeasure.Queries.GetUnitMeasureDetail
{
    public partial class GetUnitMeasureDetailQuery : IRequest<UnitMeasureLookupModel>
    {
        public string UnitMeasureCode { get; set; }
    }
}
