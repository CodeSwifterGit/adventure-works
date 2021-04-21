using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ScrapReason.Queries.GetScrapReasons;
using AdventureWorks.Application.DataEngine.Production.ScrapReason.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.ScrapReason.Commands.UpdateScrapReason
{
    public partial class UpdateScrapReasonCommandHandler : IRequestHandler<UpdateScrapReasonCommand, ScrapReasonLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly ScrapReasonsQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateScrapReasonCommandHandler(IAdventureWorksContext context,
            ScrapReasonsQueryManager queryManager,
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

        public async Task<ScrapReasonLookupModel> Handle(UpdateScrapReasonCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ScrapReasons
                .SingleAsync(c => c.ScrapReasonID == request.RequestTarget.ScrapReasonID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.ScrapReason, UpdateScrapReasonCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ScrapReason), JsonConvert.SerializeObject(new { request.RequestTarget.ScrapReasonID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.ScrapReasons.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.ScrapReasons.SingleAsync(c => c.ScrapReasonID == request.RequestTarget.ScrapReasonID, cancellationToken);

            await _mediator.Publish(new ScrapReasonUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.ScrapReason, ScrapReasonLookupModel>(entity);
        }
    }
}
