using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductDocument.Queries.GetProductDocuments;
using AdventureWorks.Application.DataEngine.Production.ProductDocument.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.ProductDocument.Commands.UpdateProductDocument
{
    public partial class UpdateProductDocumentCommandHandler : IRequestHandler<UpdateProductDocumentCommand, ProductDocumentLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly ProductDocumentsQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateProductDocumentCommandHandler(IAdventureWorksContext context,
            ProductDocumentsQueryManager queryManager,
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

        public async Task<ProductDocumentLookupModel> Handle(UpdateProductDocumentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductDocuments
                .SingleAsync(c => c.ProductID == request.RequestTarget.ProductID && c.DocumentID == request.RequestTarget.DocumentID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.ProductDocument, UpdateProductDocumentCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductDocument), JsonConvert.SerializeObject(new { request.RequestTarget.ProductID, request.RequestTarget.DocumentID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.ProductDocuments.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.ProductDocuments.SingleAsync(c => c.ProductID == request.RequestTarget.ProductID && c.DocumentID == request.RequestTarget.DocumentID, cancellationToken);

            await _mediator.Publish(new ProductDocumentUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.ProductDocument, ProductDocumentLookupModel>(entity);
        }
    }
}
