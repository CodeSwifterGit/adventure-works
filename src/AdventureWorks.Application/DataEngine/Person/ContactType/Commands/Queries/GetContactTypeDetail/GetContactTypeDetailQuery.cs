using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Person.ContactType.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Person.ContactType.Queries.GetContactTypes;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Person.ContactType.Queries.GetContactTypeDetail
{
    public partial class GetContactTypeDetailQuery : IRequest<ContactTypeLookupModel>
    {
        public int ContactTypeID { get; set; }
    }
}
