using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Application.DataEngine.Production.ProductModel.Queries.GetProductModels;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.ProductModel.Commands.UpdateProductModel
{
    public partial class UpdateProductModelCommand : IRequest<ProductModelLookupModel>, IHaveCustomMapping
    {
        public int ProductModelID { get; set; }
        public string Name { get; set; }
        public string CatalogDescription { get; set; }
        public string Instructions { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateProductModelRequestTarget RequestTarget { get; set; }

        public UpdateProductModelCommand()
        {
        }

        public UpdateProductModelCommand(int productModelID, BaseProductModel model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateProductModelRequestTarget(productModelID);
        }

        public UpdateProductModelCommand(int productModelID)
        {
            ProductModelID = productModelID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseProductModel, UpdateProductModelCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateProductModelCommand, Entities.ProductModel>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.ProductModel, Entities.ProductModel>(MemberList.None);
        }

        public partial class UpdateProductModelRequestTarget
        {
            public int ProductModelID { get; set; }

            public UpdateProductModelRequestTarget()
            {
            }

            public UpdateProductModelRequestTarget(int productModelID)
            {
                ProductModelID = productModelID;
            }
        }
    }
}