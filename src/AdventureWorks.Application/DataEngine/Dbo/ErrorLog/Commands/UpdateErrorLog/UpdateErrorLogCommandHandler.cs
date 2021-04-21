using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Dbo.ErrorLog.Queries.GetErrorLogs;
using AdventureWorks.Application.DataEngine.Dbo.ErrorLog.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Dbo;

namespace AdventureWorks.Application.DataEngine.Dbo.ErrorLog.Commands.UpdateErrorLog
{
    public partial class UpdateErrorLogCommandHandler : IRequestHandler<UpdateErrorLogCommand, ErrorLogLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly ErrorLogsQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateErrorLogCommandHandler(IAdventureWorksContext context,
            ErrorLogsQueryManager queryManager,
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

        public async Task<ErrorLogLookupModel> Handle(UpdateErrorLogCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ErrorLogs
                .SingleAsync(c => c.ErrorLogID == request.RequestTarget.ErrorLogID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.ErrorLog, UpdateErrorLogCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ErrorLog), JsonConvert.SerializeObject(new { request.RequestTarget.ErrorLogID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.ErrorLogs.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.ErrorLogs.SingleAsync(c => c.ErrorLogID == request.RequestTarget.ErrorLogID, cancellationToken);

            await _mediator.Publish(new ErrorLogUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.ErrorLog, ErrorLogLookupModel>(entity);
        }
    }
}
