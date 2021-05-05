using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Purchasing;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Purchasing;
using AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Queries.GetVendorContacts;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Commands.UpdateVendorContact
{
    public partial class UpdateVendorContactCommand : IRequest<VendorContactLookupModel>, IHaveCustomMapping
    {
        public int VendorID { get; set; }
        public int ContactID { get; set; }
        public int ContactTypeID { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateVendorContactRequestTarget RequestTarget { get; set; }

        public UpdateVendorContactCommand()
        {
        }

        public UpdateVendorContactCommand(int vendorID, int contactID, BaseVendorContact model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateVendorContactRequestTarget(vendorID, contactID);
        }

        public UpdateVendorContactCommand(int vendorID, int contactID)
        {
            VendorID = vendorID;
            ContactID = contactID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseVendorContact, UpdateVendorContactCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateVendorContactCommand, Entities.VendorContact>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.VendorContact, Entities.VendorContact>(MemberList.None);
        }

        public partial class UpdateVendorContactRequestTarget
        {
            public int VendorID { get; set; }
            public int ContactID { get; set; }

            public UpdateVendorContactRequestTarget()
            {
            }

            public UpdateVendorContactRequestTarget(int vendorID, int contactID)
            {
                VendorID = vendorID;
                ContactID = contactID;
            }
        }
    }
}