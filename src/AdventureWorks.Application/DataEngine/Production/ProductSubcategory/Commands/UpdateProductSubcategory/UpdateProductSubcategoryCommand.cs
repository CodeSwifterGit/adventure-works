using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Queries.GetProductSubcategories;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Commands.UpdateProductSubcategory
{
    public partial class UpdateProductSubcategoryCommand : BaseProductSubcategory, IRequest<ProductSubcategoryLookupModel>, IHaveCustomMapping
    {
        public int ProductSubcategoryID { get; set; }
        public int ProductCategoryID { get; set; }
        public string Name { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateProductSubcategoryRequestTarget RequestTarget { get; set; }

        public UpdateProductSubcategoryCommand()
        {
        }

        public UpdateProductSubcategoryCommand(int productSubcategoryID, BaseProductSubcategory model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateProductSubcategoryRequestTarget(productSubcategoryID);
        }

        public UpdateProductSubcategoryCommand(int productSubcategoryID)
        {
            ProductSubcategoryID = productSubcategoryID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseProductSubcategory, UpdateProductSubcategoryCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateProductSubcategoryCommand, Entities.ProductSubcategory>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.ProductSubcategory, Entities.ProductSubcategory>(MemberList.None);
        }

        public partial class UpdateProductSubcategoryRequestTarget
        {
            public int ProductSubcategoryID { get; set; }

            public UpdateProductSubcategoryRequestTarget()
            {
            }

            public UpdateProductSubcategoryRequestTarget(int productSubcategoryID)
            {
                ProductSubcategoryID = productSubcategoryID;
            }
        }
    }
}