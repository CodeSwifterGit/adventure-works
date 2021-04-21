using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Queries.GetProductModelIllustrations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Commands.UpdateProductModelIllustration
{
    public partial class UpdateProductModelIllustrationCommand : BaseProductModelIllustration, IRequest<ProductModelIllustrationLookupModel>, IHaveCustomMapping
    {
        public int ProductModelID { get; set; }
        public int IllustrationID { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateProductModelIllustrationRequestTarget RequestTarget { get; set; }

        public UpdateProductModelIllustrationCommand()
        {
        }

        public UpdateProductModelIllustrationCommand(int productModelID, int illustrationID, BaseProductModelIllustration model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateProductModelIllustrationRequestTarget(productModelID, illustrationID);
        }

        public UpdateProductModelIllustrationCommand(int productModelID, int illustrationID)
        {
            ProductModelID = productModelID;
            IllustrationID = illustrationID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseProductModelIllustration, UpdateProductModelIllustrationCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateProductModelIllustrationCommand, Entities.ProductModelIllustration>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.ProductModelIllustration, Entities.ProductModelIllustration>(MemberList.None);
        }

        public partial class UpdateProductModelIllustrationRequestTarget
        {
            public int ProductModelID { get; set; }
            public int IllustrationID { get; set; }

            public UpdateProductModelIllustrationRequestTarget()
            {
            }

            public UpdateProductModelIllustrationRequestTarget(int productModelID, int illustrationID)
            {
                ProductModelID = productModelID;
                IllustrationID = illustrationID;
            }
        }
    }
}