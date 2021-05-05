using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Person.Contact.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Person.Contact.Queries.GetContacts;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Person.Contact.Queries.GetContactDetail
{
    public partial class GetContactDetailQuery : IRequest<ContactLookupModel>
    {
        public int ContactID { get; set; }
    }
}
