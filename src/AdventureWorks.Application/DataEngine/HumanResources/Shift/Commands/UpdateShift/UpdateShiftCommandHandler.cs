using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.HumanResources.Shift.Queries.GetShifts;
using AdventureWorks.Application.DataEngine.HumanResources.Shift.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.HumanResources;

namespace AdventureWorks.Application.DataEngine.HumanResources.Shift.Commands.UpdateShift
{
    public partial class UpdateShiftCommandHandler : IRequestHandler<UpdateShiftCommand, ShiftLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly ShiftsQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateShiftCommandHandler(IAdventureWorksContext context,
            ShiftsQueryManager queryManager,
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

        public async Task<ShiftLookupModel> Handle(UpdateShiftCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Shifts
                .SingleAsync(c => c.ShiftID == request.RequestTarget.ShiftID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.Shift, UpdateShiftCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Shift), JsonConvert.SerializeObject(new { request.RequestTarget.ShiftID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.Shifts.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.Shifts.SingleAsync(c => c.ShiftID == request.RequestTarget.ShiftID, cancellationToken);

            await _mediator.Publish(new ShiftUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.Shift, ShiftLookupModel>(entity);
        }
    }
}
