using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Production.ProductPhoto.Queries.GetProductPhotos;
using AdventureWorks.Application.DataEngine.Production.ProductPhoto.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.ProductPhoto.Commands.CreateProductPhoto
{
    public partial class CreateProductPhotoCommand : BaseProductPhoto, IRequest<ProductPhotoLookupModel>, IHaveCustomMapping
    {

        public CreateProductPhotoCommand()
        {

        }

        public CreateProductPhotoCommand(BaseProductPhoto model, IMapper mapper)
        {
            mapper.Map<BaseProductPhoto, CreateProductPhotoCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateProductPhotoCommand, ProductPhotoLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly ProductPhotosQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                ProductPhotosQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<ProductPhotoLookupModel> Handle(CreateProductPhotoCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateProductPhotoCommand, Entities.ProductPhoto>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.ProductPhotos.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.ProductPhotos.FindAsync(new object[] { entity.ProductPhotoID }, cancellationToken);

                await _mediator.Publish(new ProductPhotoCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.ProductPhoto, ProductPhotoLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseProductPhoto, CreateProductPhotoCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateProductPhotoCommand, Entities.ProductPhoto>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
