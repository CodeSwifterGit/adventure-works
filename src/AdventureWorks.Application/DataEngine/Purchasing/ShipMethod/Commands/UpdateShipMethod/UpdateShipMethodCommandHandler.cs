using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Purchasing.ShipMethod.Queries.GetShipMethods;
using AdventureWorks.Application.DataEngine.Purchasing.ShipMethod.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Purchasing;

namespace AdventureWorks.Application.DataEngine.Purchasing.ShipMethod.Commands.UpdateShipMethod
{
    public partial class UpdateShipMethodCommandHandler : IRequestHandler<UpdateShipMethodCommand, ShipMethodLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly ShipMethodsQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateShipMethodCommandHandler(IAdventureWorksContext context,
            ShipMethodsQueryManager queryManager,
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

        public async Task<ShipMethodLookupModel> Handle(UpdateShipMethodCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ShipMethods
                .SingleAsync(c => c.ShipMethodID == request.RequestTarget.ShipMethodID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.ShipMethod, UpdateShipMethodCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ShipMethod), JsonConvert.SerializeObject(new { request.RequestTarget.ShipMethodID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.ShipMethods.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.ShipMethods.SingleAsync(c => c.ShipMethodID == request.RequestTarget.ShipMethodID, cancellationToken);

            await _mediator.Publish(new ShipMethodUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.ShipMethod, ShipMethodLookupModel>(entity);
        }
    }
}
