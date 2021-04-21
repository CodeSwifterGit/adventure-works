using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.TransactionHistory.Queries.GetTransactionHistories;
using AdventureWorks.Application.DataEngine.Production.TransactionHistory.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.TransactionHistory.Commands.UpdateTransactionHistory
{
    public partial class UpdateTransactionHistoryCommandHandler : IRequestHandler<UpdateTransactionHistoryCommand, TransactionHistoryLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly TransactionHistoriesQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateTransactionHistoryCommandHandler(IAdventureWorksContext context,
            TransactionHistoriesQueryManager queryManager,
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

        public async Task<TransactionHistoryLookupModel> Handle(UpdateTransactionHistoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TransactionHistories
                .SingleAsync(c => c.TransactionID == request.RequestTarget.TransactionID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.TransactionHistory, UpdateTransactionHistoryCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TransactionHistory), JsonConvert.SerializeObject(new { request.RequestTarget.TransactionID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.TransactionHistories.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.TransactionHistories.SingleAsync(c => c.TransactionID == request.RequestTarget.TransactionID, cancellationToken);

            await _mediator.Publish(new TransactionHistoryUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.TransactionHistory, TransactionHistoryLookupModel>(entity);
        }
    }
}
