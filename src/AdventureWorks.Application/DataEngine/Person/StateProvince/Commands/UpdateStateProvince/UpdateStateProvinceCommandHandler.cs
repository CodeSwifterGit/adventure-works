using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Person.StateProvince.Queries.GetStateProvinces;
using AdventureWorks.Application.DataEngine.Person.StateProvince.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Person;

namespace AdventureWorks.Application.DataEngine.Person.StateProvince.Commands.UpdateStateProvince
{
    public partial class UpdateStateProvinceCommandHandler : IRequestHandler<UpdateStateProvinceCommand, StateProvinceLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly StateProvincesQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateStateProvinceCommandHandler(IAdventureWorksContext context,
            StateProvincesQueryManager queryManager,
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

        public async Task<StateProvinceLookupModel> Handle(UpdateStateProvinceCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.StateProvinces
                .SingleAsync(c => c.StateProvinceID == request.RequestTarget.StateProvinceID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.StateProvince, UpdateStateProvinceCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(StateProvince), JsonConvert.SerializeObject(new { request.RequestTarget.StateProvinceID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.StateProvinces.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.StateProvinces.SingleAsync(c => c.StateProvinceID == request.RequestTarget.StateProvinceID, cancellationToken);

            await _mediator.Publish(new StateProvinceUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.StateProvince, StateProvinceLookupModel>(entity);
        }
    }
}
