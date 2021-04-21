using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Purchasing;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Purchasing;
using AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Queries.GetVendorAddresses;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Commands.UpdateVendorAddress
{
    public partial class UpdateVendorAddressCommand : BaseVendorAddress, IRequest<VendorAddressLookupModel>, IHaveCustomMapping
    {
        public int VendorID { get; set; }
        public int AddressID { get; set; }
        public int AddressTypeID { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateVendorAddressRequestTarget RequestTarget { get; set; }

        public UpdateVendorAddressCommand()
        {
        }

        public UpdateVendorAddressCommand(int vendorID, int addressID, BaseVendorAddress model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateVendorAddressRequestTarget(vendorID, addressID);
        }

        public UpdateVendorAddressCommand(int vendorID, int addressID)
        {
            VendorID = vendorID;
            AddressID = addressID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseVendorAddress, UpdateVendorAddressCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateVendorAddressCommand, Entities.VendorAddress>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.VendorAddress, Entities.VendorAddress>(MemberList.None);
        }

        public partial class UpdateVendorAddressRequestTarget
        {
            public int VendorID { get; set; }
            public int AddressID { get; set; }

            public UpdateVendorAddressRequestTarget()
            {
            }

            public UpdateVendorAddressRequestTarget(int vendorID, int addressID)
            {
                VendorID = vendorID;
                AddressID = addressID;
            }
        }
    }
}