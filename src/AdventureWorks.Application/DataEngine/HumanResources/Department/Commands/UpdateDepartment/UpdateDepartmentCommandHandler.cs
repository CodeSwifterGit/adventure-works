using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.HumanResources.Department.Queries.GetDepartments;
using AdventureWorks.Application.DataEngine.HumanResources.Department.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.HumanResources;

namespace AdventureWorks.Application.DataEngine.HumanResources.Department.Commands.UpdateDepartment
{
    public partial class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, DepartmentLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly DepartmentsQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateDepartmentCommandHandler(IAdventureWorksContext context,
            DepartmentsQueryManager queryManager,
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

        public async Task<DepartmentLookupModel> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Departments
                .SingleAsync(c => c.DepartmentID == request.RequestTarget.DepartmentID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.Department, UpdateDepartmentCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Department), JsonConvert.SerializeObject(new { request.RequestTarget.DepartmentID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.Departments.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.Departments.SingleAsync(c => c.DepartmentID == request.RequestTarget.DepartmentID, cancellationToken);

            await _mediator.Publish(new DepartmentUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.Department, DepartmentLookupModel>(entity);
        }
    }
}
