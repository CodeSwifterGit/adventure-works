using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Queries.GetSalesPersonQuotaHistories;
using AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Commands.UpdateSalesPersonQuotaHistory
{
    public partial class UpdateSalesPersonQuotaHistoryCommandHandler : IRequestHandler<UpdateSalesPersonQuotaHistoryCommand, SalesPersonQuotaHistoryLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly SalesPersonQuotaHistoriesQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateSalesPersonQuotaHistoryCommandHandler(IAdventureWorksContext context,
            SalesPersonQuotaHistoriesQueryManager queryManager,
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

        public async Task<SalesPersonQuotaHistoryLookupModel> Handle(UpdateSalesPersonQuotaHistoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.SalesPersonQuotaHistories
                .SingleAsync(c => c.SalesPersonID == request.RequestTarget.SalesPersonID && c.QuotaDate == request.RequestTarget.QuotaDate, cancellationToken);
            var oldEntity = _mapper.Map<Entities.SalesPersonQuotaHistory, UpdateSalesPersonQuotaHistoryCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(SalesPersonQuotaHistory), JsonConvert.SerializeObject(new { request.RequestTarget.SalesPersonID, request.RequestTarget.QuotaDate }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.SalesPersonQuotaHistories.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.SalesPersonQuotaHistories.SingleAsync(c => c.SalesPersonID == request.RequestTarget.SalesPersonID && c.QuotaDate == request.RequestTarget.QuotaDate, cancellationToken);

            await _mediator.Publish(new SalesPersonQuotaHistoryUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.SalesPersonQuotaHistory, SalesPersonQuotaHistoryLookupModel>(entity);
        }
    }
}
