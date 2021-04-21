using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Queries.GetProductProductPhotos;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Commands.UpdateProductProductPhoto
{
    public partial class UpdateProductProductPhotoCommand : BaseProductProductPhoto, IRequest<ProductProductPhotoLookupModel>, IHaveCustomMapping
    {
        public int ProductID { get; set; }
        public int ProductPhotoID { get; set; }
        public bool Primary { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateProductProductPhotoRequestTarget RequestTarget { get; set; }

        public UpdateProductProductPhotoCommand()
        {
        }

        public UpdateProductProductPhotoCommand(int productID, int productPhotoID, BaseProductProductPhoto model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateProductProductPhotoRequestTarget(productID, productPhotoID);
        }

        public UpdateProductProductPhotoCommand(int productID, int productPhotoID)
        {
            ProductID = productID;
            ProductPhotoID = productPhotoID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseProductProductPhoto, UpdateProductProductPhotoCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateProductProductPhotoCommand, Entities.ProductProductPhoto>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.ProductProductPhoto, Entities.ProductProductPhoto>(MemberList.None);
        }

        public partial class UpdateProductProductPhotoRequestTarget
        {
            public int ProductID { get; set; }
            public int ProductPhotoID { get; set; }

            public UpdateProductProductPhotoRequestTarget()
            {
            }

            public UpdateProductProductPhotoRequestTarget(int productID, int productPhotoID)
            {
                ProductID = productID;
                ProductPhotoID = productPhotoID;
            }
        }
    }
}