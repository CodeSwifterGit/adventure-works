using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Queries.GetVendorAddresses;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Purchasing;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Purchasing;


namespace AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Commands.UpdateVendorAddress
{
    public partial class UpdateVendorAddressSetCommand : IRequest<List<VendorAddressLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateVendorAddressCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseVendorAddress>, List<UpdateVendorAddressCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateVendorAddressCommand>, List<Entities.VendorAddress>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.VendorAddress>, List<Entities.VendorAddress>>(MemberList.None);
        }
    }
}