using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Queries.GetProductModelProductDescriptionCultures;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Commands.UpdateProductModelProductDescriptionCulture
{
    public partial class UpdateProductModelProductDescriptionCultureCommand : BaseProductModelProductDescriptionCulture, IRequest<ProductModelProductDescriptionCultureLookupModel>, IHaveCustomMapping
    {
        public int ProductModelID { get; set; }
        public int ProductDescriptionID { get; set; }
        public string CultureID { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateProductModelProductDescriptionCultureRequestTarget RequestTarget { get; set; }

        public UpdateProductModelProductDescriptionCultureCommand()
        {
        }

        public UpdateProductModelProductDescriptionCultureCommand(int productModelID, int productDescriptionID, string cultureID, BaseProductModelProductDescriptionCulture model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateProductModelProductDescriptionCultureRequestTarget(productModelID, productDescriptionID, cultureID);
        }

        public UpdateProductModelProductDescriptionCultureCommand(int productModelID, int productDescriptionID, string cultureID)
        {
            ProductModelID = productModelID;
            ProductDescriptionID = productDescriptionID;
            CultureID = cultureID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseProductModelProductDescriptionCulture, UpdateProductModelProductDescriptionCultureCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateProductModelProductDescriptionCultureCommand, Entities.ProductModelProductDescriptionCulture>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.ProductModelProductDescriptionCulture, Entities.ProductModelProductDescriptionCulture>(MemberList.None);
        }

        public partial class UpdateProductModelProductDescriptionCultureRequestTarget
        {
            public int ProductModelID { get; set; }
            public int ProductDescriptionID { get; set; }
            public string CultureID { get; set; }

            public UpdateProductModelProductDescriptionCultureRequestTarget()
            {
            }

            public UpdateProductModelProductDescriptionCultureRequestTarget(int productModelID, int productDescriptionID, string cultureID)
            {
                ProductModelID = productModelID;
                ProductDescriptionID = productDescriptionID;
                CultureID = cultureID;
            }
        }
    }
}