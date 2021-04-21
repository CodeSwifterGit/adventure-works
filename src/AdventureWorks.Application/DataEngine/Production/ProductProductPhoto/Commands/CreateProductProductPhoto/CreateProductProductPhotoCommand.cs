using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Queries.GetProductProductPhotos;
using AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Commands.CreateProductProductPhoto
{
    public partial class CreateProductProductPhotoCommand : BaseProductProductPhoto, IRequest<ProductProductPhotoLookupModel>, IHaveCustomMapping
    {

        public CreateProductProductPhotoCommand()
        {

        }

        public CreateProductProductPhotoCommand(BaseProductProductPhoto model, IMapper mapper)
        {
            mapper.Map<BaseProductProductPhoto, CreateProductProductPhotoCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateProductProductPhotoCommand, ProductProductPhotoLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly ProductProductPhotosQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                ProductProductPhotosQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<ProductProductPhotoLookupModel> Handle(CreateProductProductPhotoCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateProductProductPhotoCommand, Entities.ProductProductPhoto>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.ProductProductPhotos.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.ProductProductPhotos.FindAsync(new object[] { entity.ProductID, entity.ProductPhotoID }, cancellationToken);

                await _mediator.Publish(new ProductProductPhotoCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.ProductProductPhoto, ProductProductPhotoLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseProductProductPhoto, CreateProductProductPhotoCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateProductProductPhotoCommand, Entities.ProductProductPhoto>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
