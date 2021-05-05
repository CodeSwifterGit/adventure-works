using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Person.StateProvince.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Person.StateProvince.Queries.GetStateProvinces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Person.StateProvince.Queries.GetStateProvinceDetail
{
    public partial class GetStateProvinceDetailQuery : IRequest<StateProvinceLookupModel>
    {
        public int StateProvinceID { get; set; }
    }
}
