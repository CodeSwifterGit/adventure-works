using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.TransactionHistoryArchive.Queries.GetTransactionHistoryArchives;
using AdventureWorks.Application.DataEngine.Production.TransactionHistoryArchive.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.TransactionHistoryArchive.Commands.UpdateTransactionHistoryArchive
{
    public partial class UpdateTransactionHistoryArchiveCommandHandler : IRequestHandler<UpdateTransactionHistoryArchiveCommand, TransactionHistoryArchiveLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly TransactionHistoryArchivesQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateTransactionHistoryArchiveCommandHandler(IAdventureWorksContext context,
            TransactionHistoryArchivesQueryManager queryManager,
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

        public async Task<TransactionHistoryArchiveLookupModel> Handle(UpdateTransactionHistoryArchiveCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TransactionHistoryArchives
                .SingleAsync(c => c.TransactionID == request.RequestTarget.TransactionID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.TransactionHistoryArchive, UpdateTransactionHistoryArchiveCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TransactionHistoryArchive), JsonConvert.SerializeObject(new { request.RequestTarget.TransactionID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.TransactionHistoryArchives.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.TransactionHistoryArchives.SingleAsync(c => c.TransactionID == request.RequestTarget.TransactionID, cancellationToken);

            await _mediator.Publish(new TransactionHistoryArchiveUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.TransactionHistoryArchive, TransactionHistoryArchiveLookupModel>(entity);
        }
    }
}
