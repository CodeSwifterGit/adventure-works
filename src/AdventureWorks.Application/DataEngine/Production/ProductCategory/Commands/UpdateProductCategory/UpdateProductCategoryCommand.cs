using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Application.DataEngine.Production.ProductCategory.Queries.GetProductCategories;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.ProductCategory.Commands.UpdateProductCategory
{
    public partial class UpdateProductCategoryCommand : BaseProductCategory, IRequest<ProductCategoryLookupModel>, IHaveCustomMapping
    {
        public int ProductCategoryID { get; set; }
        public string Name { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateProductCategoryRequestTarget RequestTarget { get; set; }

        public UpdateProductCategoryCommand()
        {
        }

        public UpdateProductCategoryCommand(int productCategoryID, BaseProductCategory model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateProductCategoryRequestTarget(productCategoryID);
        }

        public UpdateProductCategoryCommand(int productCategoryID)
        {
            ProductCategoryID = productCategoryID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseProductCategory, UpdateProductCategoryCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateProductCategoryCommand, Entities.ProductCategory>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.ProductCategory, Entities.ProductCategory>(MemberList.None);
        }

        public partial class UpdateProductCategoryRequestTarget
        {
            public int ProductCategoryID { get; set; }

            public UpdateProductCategoryRequestTarget()
            {
            }

            public UpdateProductCategoryRequestTarget(int productCategoryID)
            {
                ProductCategoryID = productCategoryID;
            }
        }
    }
}