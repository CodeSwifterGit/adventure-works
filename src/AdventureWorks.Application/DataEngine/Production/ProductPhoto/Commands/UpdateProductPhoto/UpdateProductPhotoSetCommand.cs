using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductPhoto.Queries.GetProductPhotos;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.ProductPhoto.Commands.UpdateProductPhoto
{
    public partial class UpdateProductPhotoSetCommand : IRequest<List<ProductPhotoLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateProductPhotoCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseProductPhoto>, List<UpdateProductPhotoCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateProductPhotoCommand>, List<Entities.ProductPhoto>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.ProductPhoto>, List<Entities.ProductPhoto>>(MemberList.None);
        }
    }
}