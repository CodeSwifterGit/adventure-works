using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.Document.Queries.GetDocuments;
using AdventureWorks.Application.DataEngine.Production.Document.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.Document.Commands.UpdateDocument
{
    public partial class UpdateDocumentCommandHandler : IRequestHandler<UpdateDocumentCommand, DocumentLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly DocumentsQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateDocumentCommandHandler(IAdventureWorksContext context,
            DocumentsQueryManager queryManager,
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

        public async Task<DocumentLookupModel> Handle(UpdateDocumentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Documents
                .SingleAsync(c => c.DocumentID == request.RequestTarget.DocumentID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.Document, UpdateDocumentCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Document), JsonConvert.SerializeObject(new { request.RequestTarget.DocumentID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.Documents.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.Documents.SingleAsync(c => c.DocumentID == request.RequestTarget.DocumentID, cancellationToken);

            await _mediator.Publish(new DocumentUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.Document, DocumentLookupModel>(entity);
        }
    }
}
