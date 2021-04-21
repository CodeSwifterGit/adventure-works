using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Purchasing.Vendor.Queries.GetVendors;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Purchasing;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Purchasing;


namespace AdventureWorks.Application.DataEngine.Purchasing.Vendor.Commands.UpdateVendor
{
    public partial class UpdateVendorSetCommand : IRequest<List<VendorLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateVendorCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseVendor>, List<UpdateVendorCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateVendorCommand>, List<Entities.Vendor>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.Vendor>, List<Entities.Vendor>>(MemberList.None);
        }
    }
}