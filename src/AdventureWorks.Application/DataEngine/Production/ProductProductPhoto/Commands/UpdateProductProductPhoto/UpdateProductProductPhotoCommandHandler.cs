using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Queries.GetProductProductPhotos;
using AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Commands.UpdateProductProductPhoto
{
    public partial class UpdateProductProductPhotoCommandHandler : IRequestHandler<UpdateProductProductPhotoCommand, ProductProductPhotoLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly ProductProductPhotosQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateProductProductPhotoCommandHandler(IAdventureWorksContext context,
            ProductProductPhotosQueryManager queryManager,
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

        public async Task<ProductProductPhotoLookupModel> Handle(UpdateProductProductPhotoCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductProductPhotos
                .SingleAsync(c => c.ProductID == request.RequestTarget.ProductID && c.ProductPhotoID == request.RequestTarget.ProductPhotoID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.ProductProductPhoto, UpdateProductProductPhotoCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductProductPhoto), JsonConvert.SerializeObject(new { request.RequestTarget.ProductID, request.RequestTarget.ProductPhotoID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.ProductProductPhotos.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.ProductProductPhotos.SingleAsync(c => c.ProductID == request.RequestTarget.ProductID && c.ProductPhotoID == request.RequestTarget.ProductPhotoID, cancellationToken);

            await _mediator.Publish(new ProductProductPhotoUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.ProductProductPhoto, ProductProductPhotoLookupModel>(entity);
        }
    }
}
