using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Application.DataEngine.Production.ProductPhoto.Queries.GetProductPhotos;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.ProductPhoto.Commands.UpdateProductPhoto
{
    public partial class UpdateProductPhotoCommand : BaseProductPhoto, IRequest<ProductPhotoLookupModel>, IHaveCustomMapping
    {
        public int ProductPhotoID { get; set; }
        public byte[] ThumbNailPhoto { get; set; }
        public string ThumbnailPhotoFileName { get; set; }
        public byte[] LargePhoto { get; set; }
        public string LargePhotoFileName { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateProductPhotoRequestTarget RequestTarget { get; set; }

        public UpdateProductPhotoCommand()
        {
        }

        public UpdateProductPhotoCommand(int productPhotoID, BaseProductPhoto model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateProductPhotoRequestTarget(productPhotoID);
        }

        public UpdateProductPhotoCommand(int productPhotoID)
        {
            ProductPhotoID = productPhotoID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseProductPhoto, UpdateProductPhotoCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateProductPhotoCommand, Entities.ProductPhoto>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.ProductPhoto, Entities.ProductPhoto>(MemberList.None);
        }

        public partial class UpdateProductPhotoRequestTarget
        {
            public int ProductPhotoID { get; set; }

            public UpdateProductPhotoRequestTarget()
            {
            }

            public UpdateProductPhotoRequestTarget(int productPhotoID)
            {
                ProductPhotoID = productPhotoID;
            }
        }
    }
}