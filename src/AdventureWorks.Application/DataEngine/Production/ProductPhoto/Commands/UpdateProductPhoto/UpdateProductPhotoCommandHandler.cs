using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductPhoto.Queries.GetProductPhotos;
using AdventureWorks.Application.DataEngine.Production.ProductPhoto.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.ProductPhoto.Commands.UpdateProductPhoto
{
    public partial class UpdateProductPhotoCommandHandler : IRequestHandler<UpdateProductPhotoCommand, ProductPhotoLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly ProductPhotosQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateProductPhotoCommandHandler(IAdventureWorksContext context,
            ProductPhotosQueryManager queryManager,
            IAuthenticatedUserService authenticatedUserService,
            IMediator mediator,
            IMapper mapper,
            IDateTime machineDateTime)
        {
            _context = context;
            _queryManager = queryManager;
            _authenticatedUserService = authenticatedUserService;
            _mediator = mediator;
            _mapper = mapper;
            _machineDateTime = machineDateTime;
        }

        public async Task<ProductPhotoLookupModel> Handle(UpdateProductPhotoCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductPhotos
                .SingleAsync(c => c.ProductPhotoID == request.RequestTarget.ProductPhotoID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.ProductPhoto, UpdateProductPhotoCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductPhoto), JsonConvert.SerializeObject(new { request.RequestTarget.ProductPhotoID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.ProductPhotos.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.ProductPhotos.SingleAsync(c => c.ProductPhotoID == request.RequestTarget.ProductPhotoID, cancellationToken);

            await _mediator.Publish(new ProductPhotoUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.ProductPhoto, ProductPhotoLookupModel>(entity);
        }
    }
}
