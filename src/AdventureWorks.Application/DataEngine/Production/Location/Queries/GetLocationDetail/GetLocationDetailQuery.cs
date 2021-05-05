using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Production.Location.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Production.Location.Queries.GetLocations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.Location.Queries.GetLocationDetail
{
    public partial class GetLocationDetailQuery : IRequest<LocationLookupModel>
    {
        public short LocationID { get; set; }
    }
}
