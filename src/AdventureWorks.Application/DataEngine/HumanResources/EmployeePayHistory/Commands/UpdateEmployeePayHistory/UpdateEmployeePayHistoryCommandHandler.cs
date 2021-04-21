using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Queries.GetEmployeePayHistories;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.HumanResources;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Commands.UpdateEmployeePayHistory
{
    public partial class UpdateEmployeePayHistoryCommandHandler : IRequestHandler<UpdateEmployeePayHistoryCommand, EmployeePayHistoryLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly EmployeePayHistoriesQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateEmployeePayHistoryCommandHandler(IAdventureWorksContext context,
            EmployeePayHistoriesQueryManager queryManager,
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

        public async Task<EmployeePayHistoryLookupModel> Handle(UpdateEmployeePayHistoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.EmployeePayHistories
                .SingleAsync(c => c.EmployeeID == request.RequestTarget.EmployeeID && c.RateChangeDate == request.RequestTarget.RateChangeDate, cancellationToken);
            var oldEntity = _mapper.Map<Entities.EmployeePayHistory, UpdateEmployeePayHistoryCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(EmployeePayHistory), JsonConvert.SerializeObject(new { request.RequestTarget.EmployeeID, request.RequestTarget.RateChangeDate }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.EmployeePayHistories.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.EmployeePayHistories.SingleAsync(c => c.EmployeeID == request.RequestTarget.EmployeeID && c.RateChangeDate == request.RequestTarget.RateChangeDate, cancellationToken);

            await _mediator.Publish(new EmployeePayHistoryUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.EmployeePayHistory, EmployeePayHistoryLookupModel>(entity);
        }
    }
}
