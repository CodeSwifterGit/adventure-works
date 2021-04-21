using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Queries.GetEmployeeDepartmentHistories;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.HumanResources;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Commands.UpdateEmployeeDepartmentHistory
{
    public partial class UpdateEmployeeDepartmentHistoryCommandHandler : IRequestHandler<UpdateEmployeeDepartmentHistoryCommand, EmployeeDepartmentHistoryLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly EmployeeDepartmentHistoriesQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateEmployeeDepartmentHistoryCommandHandler(IAdventureWorksContext context,
            EmployeeDepartmentHistoriesQueryManager queryManager,
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

        public async Task<EmployeeDepartmentHistoryLookupModel> Handle(UpdateEmployeeDepartmentHistoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.EmployeeDepartmentHistories
                .SingleAsync(c => c.EmployeeID == request.RequestTarget.EmployeeID && c.DepartmentID == request.RequestTarget.DepartmentID && c.ShiftID == request.RequestTarget.ShiftID && c.StartDate == request.RequestTarget.StartDate, cancellationToken);
            var oldEntity = _mapper.Map<Entities.EmployeeDepartmentHistory, UpdateEmployeeDepartmentHistoryCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(EmployeeDepartmentHistory), JsonConvert.SerializeObject(new { request.RequestTarget.EmployeeID, request.RequestTarget.DepartmentID, request.RequestTarget.ShiftID, request.RequestTarget.StartDate }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.EmployeeDepartmentHistories.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.EmployeeDepartmentHistories.SingleAsync(c => c.EmployeeID == request.RequestTarget.EmployeeID && c.DepartmentID == request.RequestTarget.DepartmentID && c.ShiftID == request.RequestTarget.ShiftID && c.StartDate == request.RequestTarget.StartDate, cancellationToken);

            await _mediator.Publish(new EmployeeDepartmentHistoryUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.EmployeeDepartmentHistory, EmployeeDepartmentHistoryLookupModel>(entity);
        }
    }
}
