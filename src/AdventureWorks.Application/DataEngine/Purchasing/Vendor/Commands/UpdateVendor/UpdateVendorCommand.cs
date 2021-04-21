using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Purchasing;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Purchasing;
using AdventureWorks.Application.DataEngine.Purchasing.Vendor.Queries.GetVendors;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Purchasing.Vendor.Commands.UpdateVendor
{
    public partial class UpdateVendorCommand : BaseVendor, IRequest<VendorLookupModel>, IHaveCustomMapping
    {
        public int VendorID { get; set; }
        public string AccountNumber { get; set; }
        public string Name { get; set; }
        public byte CreditRating { get; set; }
        public bool PreferredVendorStatus { get; set; }
        public bool ActiveFlag { get; set; }
        public string PurchasingWebServiceURL { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateVendorRequestTarget RequestTarget { get; set; }

        public UpdateVendorCommand()
        {
        }

        public UpdateVendorCommand(int vendorID, BaseVendor model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateVendorRequestTarget(vendorID);
        }

        public UpdateVendorCommand(int vendorID)
        {
            VendorID = vendorID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseVendor, UpdateVendorCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateVendorCommand, Entities.Vendor>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.Vendor, Entities.Vendor>(MemberList.None);
        }

        public partial class UpdateVendorRequestTarget
        {
            public int VendorID { get; set; }

            public UpdateVendorRequestTarget()
            {
            }

            public UpdateVendorRequestTarget(int vendorID)
            {
                VendorID = vendorID;
            }
        }
    }
}