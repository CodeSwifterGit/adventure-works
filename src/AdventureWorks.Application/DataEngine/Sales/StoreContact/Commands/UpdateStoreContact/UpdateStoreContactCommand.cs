using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Application.DataEngine.Sales.StoreContact.Queries.GetStoreContacts;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.StoreContact.Commands.UpdateStoreContact
{
    public partial class UpdateStoreContactCommand : IRequest<StoreContactLookupModel>, IHaveCustomMapping
    {
        public int CustomerID { get; set; }
        public int ContactID { get; set; }
        public int ContactTypeID { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateStoreContactRequestTarget RequestTarget { get; set; }

        public UpdateStoreContactCommand()
        {
        }

        public UpdateStoreContactCommand(int customerID, int contactID, BaseStoreContact model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateStoreContactRequestTarget(customerID, contactID);
        }

        public UpdateStoreContactCommand(int customerID, int contactID)
        {
            CustomerID = customerID;
            ContactID = contactID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseStoreContact, UpdateStoreContactCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateStoreContactCommand, Entities.StoreContact>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.StoreContact, Entities.StoreContact>(MemberList.None);
        }

        public partial class UpdateStoreContactRequestTarget
        {
            public int CustomerID { get; set; }
            public int ContactID { get; set; }

            public UpdateStoreContactRequestTarget()
            {
            }

            public UpdateStoreContactRequestTarget(int customerID, int contactID)
            {
                CustomerID = customerID;
                ContactID = contactID;
            }
        }
    }
}