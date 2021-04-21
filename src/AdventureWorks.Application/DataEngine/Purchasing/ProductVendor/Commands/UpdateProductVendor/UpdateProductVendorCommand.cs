using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Purchasing;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Purchasing;
using AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Queries.GetProductVendors;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Commands.UpdateProductVendor
{
    public partial class UpdateProductVendorCommand : BaseProductVendor, IRequest<ProductVendorLookupModel>, IHaveCustomMapping
    {
        public int ProductID { get; set; }
        public int VendorID { get; set; }
        public int AverageLeadTime { get; set; }
        public decimal StandardPrice { get; set; }
        public decimal? LastReceiptCost { get; set; }
        public DateTime? LastReceiptDate { get; set; }
        public int MinOrderQty { get; set; }
        public int MaxOrderQty { get; set; }
        public int? OnOrderQty { get; set; }
        public string UnitMeasureCode { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateProductVendorRequestTarget RequestTarget { get; set; }

        public UpdateProductVendorCommand()
        {
        }

        public UpdateProductVendorCommand(int productID, int vendorID, BaseProductVendor model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateProductVendorRequestTarget(productID, vendorID);
        }

        public UpdateProductVendorCommand(int productID, int vendorID)
        {
            ProductID = productID;
            VendorID = vendorID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseProductVendor, UpdateProductVendorCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateProductVendorCommand, Entities.ProductVendor>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.ProductVendor, Entities.ProductVendor>(MemberList.None);
        }

        public partial class UpdateProductVendorRequestTarget
        {
            public int ProductID { get; set; }
            public int VendorID { get; set; }

            public UpdateProductVendorRequestTarget()
            {
            }

            public UpdateProductVendorRequestTarget(int productID, int vendorID)
            {
                ProductID = productID;
                VendorID = vendorID;
            }
        }
    }
}