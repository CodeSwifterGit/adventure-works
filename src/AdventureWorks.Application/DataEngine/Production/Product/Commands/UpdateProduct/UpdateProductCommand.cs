using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Application.DataEngine.Production.Product.Queries.GetProducts;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.Product.Commands.UpdateProduct
{
    public partial class UpdateProductCommand : IRequest<ProductLookupModel>, IHaveCustomMapping
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public bool MakeFlag { get; set; }
        public bool FinishedGoodsFlag { get; set; }
        public string Color { get; set; }
        public short SafetyStockLevel { get; set; }
        public short ReorderPoint { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public string Size { get; set; }
        public string SizeUnitMeasureCode { get; set; }
        public string WeightUnitMeasureCode { get; set; }
        public decimal? Weight { get; set; }
        public int DaysToManufacture { get; set; }
        public string ProductLine { get; set; }
        public string Class { get; set; }
        public string Style { get; set; }
        public int? ProductSubcategoryID { get; set; }
        public int? ProductModelID { get; set; }
        public DateTime SellStartDate { get; set; }
        public DateTime? SellEndDate { get; set; }
        public DateTime? DiscontinuedDate { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateProductRequestTarget RequestTarget { get; set; }

        public UpdateProductCommand()
        {
        }

        public UpdateProductCommand(int productID, BaseProduct model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateProductRequestTarget(productID);
        }

        public UpdateProductCommand(int productID)
        {
            ProductID = productID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseProduct, UpdateProductCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateProductCommand, Entities.Product>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.Product, Entities.Product>(MemberList.None);
        }

        public partial class UpdateProductRequestTarget
        {
            public int ProductID { get; set; }

            public UpdateProductRequestTarget()
            {
            }

            public UpdateProductRequestTarget(int productID)
            {
                ProductID = productID;
            }
        }
    }
}