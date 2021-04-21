using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Dbo.DatabaseLog.Queries.GetDatabaseLogs;
using AdventureWorks.Application.DataEngine.Dbo.DatabaseLog.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Dbo;

namespace AdventureWorks.Application.DataEngine.Dbo.DatabaseLog.Commands.UpdateDatabaseLog
{
    public partial class UpdateDatabaseLogCommandHandler : IRequestHandler<UpdateDatabaseLogCommand, DatabaseLogLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly DatabaseLogsQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateDatabaseLogCommandHandler(IAdventureWorksContext context,
            DatabaseLogsQueryManager queryManager,
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

        public async Task<DatabaseLogLookupModel> Handle(UpdateDatabaseLogCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.DatabaseLogs
                .SingleAsync(c => c.DatabaseLogID == request.RequestTarget.DatabaseLogID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.DatabaseLog, UpdateDatabaseLogCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(DatabaseLog), JsonConvert.SerializeObject(new { request.RequestTarget.DatabaseLogID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.DatabaseLogs.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.DatabaseLogs.SingleAsync(c => c.DatabaseLogID == request.RequestTarget.DatabaseLogID, cancellationToken);

            await _mediator.Publish(new DatabaseLogUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.DatabaseLog, DatabaseLogLookupModel>(entity);
        }
    }
}
