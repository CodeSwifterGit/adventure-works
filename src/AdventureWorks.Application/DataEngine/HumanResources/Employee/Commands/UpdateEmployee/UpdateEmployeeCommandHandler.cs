using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.HumanResources.Employee.Queries.GetEmployees;
using AdventureWorks.Application.DataEngine.HumanResources.Employee.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.HumanResources;

namespace AdventureWorks.Application.DataEngine.HumanResources.Employee.Commands.UpdateEmployee
{
    public partial class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly EmployeesQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateEmployeeCommandHandler(IAdventureWorksContext context,
            EmployeesQueryManager queryManager,
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

        public async Task<EmployeeLookupModel> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Employees
                .SingleAsync(c => c.EmployeeID == request.RequestTarget.EmployeeID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.Employee, UpdateEmployeeCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Employee), JsonConvert.SerializeObject(new { request.RequestTarget.EmployeeID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.Employees.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.Employees.SingleAsync(c => c.EmployeeID == request.RequestTarget.EmployeeID, cancellationToken);

            await _mediator.Publish(new EmployeeUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.Employee, EmployeeLookupModel>(entity);
        }
    }
}
