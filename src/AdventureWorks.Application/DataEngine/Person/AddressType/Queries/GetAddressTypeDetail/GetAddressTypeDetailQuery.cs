using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Person.AddressType.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Person.AddressType.Queries.GetAddressTypes;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Person.AddressType.Queries.GetAddressTypeDetail
{
    public partial class GetAddressTypeDetailQuery : IRequest<AddressTypeLookupModel>
    {
        public int AddressTypeID { get; set; }
    }
}
