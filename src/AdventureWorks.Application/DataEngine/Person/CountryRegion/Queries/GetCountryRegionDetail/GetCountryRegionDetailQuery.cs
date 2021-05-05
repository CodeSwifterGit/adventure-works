using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Person.CountryRegion.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Person.CountryRegion.Queries.GetCountryRegions;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Person.CountryRegion.Queries.GetCountryRegionDetail
{
    public partial class GetCountryRegionDetailQuery : IRequest<CountryRegionLookupModel>
    {
        public string CountryRegionCode { get; set; }
    }
}
