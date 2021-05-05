using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Application.DataEngine.Production.ProductDescription.Queries.GetProductDescriptions;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.ProductDescription.Commands.UpdateProductDescription
{
    public partial class UpdateProductDescriptionCommand : IRequest<ProductDescriptionLookupModel>, IHaveCustomMapping
    {
        public int ProductDescriptionID { get; set; }
        public string Description { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateProductDescriptionRequestTarget RequestTarget { get; set; }

        public UpdateProductDescriptionCommand()
        {
        }

        public UpdateProductDescriptionCommand(int productDescriptionID, BaseProductDescription model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateProductDescriptionRequestTarget(productDescriptionID);
        }

        public UpdateProductDescriptionCommand(int productDescriptionID)
        {
            ProductDescriptionID = productDescriptionID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseProductDescription, UpdateProductDescriptionCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateProductDescriptionCommand, Entities.ProductDescription>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.ProductDescription, Entities.ProductDescription>(MemberList.None);
        }

        public partial class UpdateProductDescriptionRequestTarget
        {
            public int ProductDescriptionID { get; set; }

            public UpdateProductDescriptionRequestTarget()
            {
            }

            public UpdateProductDescriptionRequestTarget(int productDescriptionID)
            {
                ProductDescriptionID = productDescriptionID;
            }
        }
    }
}