using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Queries.GetProductVendors;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Purchasing;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Purchasing;


namespace AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Commands.UpdateProductVendor
{
    public partial class UpdateProductVendorSetCommand : IRequest<List<ProductVendorLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateProductVendorCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseProductVendor>, List<UpdateProductVendorCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateProductVendorCommand>, List<Entities.ProductVendor>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.ProductVendor>, List<Entities.ProductVendor>>(MemberList.None);
        }
    }
}