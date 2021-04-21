using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Queries.GetProductProductPhotos;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Commands.UpdateProductProductPhoto
{
    public partial class UpdateProductProductPhotoSetCommand : IRequest<List<ProductProductPhotoLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateProductProductPhotoCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseProductProductPhoto>, List<UpdateProductProductPhotoCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateProductProductPhotoCommand>, List<Entities.ProductProductPhoto>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.ProductProductPhoto>, List<Entities.ProductProductPhoto>>(MemberList.None);
        }
    }
}