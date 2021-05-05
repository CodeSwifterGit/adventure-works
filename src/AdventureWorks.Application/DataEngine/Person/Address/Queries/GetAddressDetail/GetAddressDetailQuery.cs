using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Person.Address.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Person.Address.Queries.GetAddresses;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Person.Address.Queries.GetAddressDetail
{
    public partial class GetAddressDetailQuery : IRequest<AddressLookupModel>
    {
        public int AddressID { get; set; }
    }
}
