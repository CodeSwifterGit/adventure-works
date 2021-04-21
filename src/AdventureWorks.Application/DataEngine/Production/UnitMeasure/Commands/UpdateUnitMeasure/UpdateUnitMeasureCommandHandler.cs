using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.UnitMeasure.Queries.GetUnitMeasures;
using AdventureWorks.Application.DataEngine.Production.UnitMeasure.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.UnitMeasure.Commands.UpdateUnitMeasure
{
    public partial class UpdateUnitMeasureCommandHandler : IRequestHandler<UpdateUnitMeasureCommand, UnitMeasureLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly UnitMeasuresQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateUnitMeasureCommandHandler(IAdventureWorksContext context,
            UnitMeasuresQueryManager queryManager,
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

        public async Task<UnitMeasureLookupModel> Handle(UpdateUnitMeasureCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.UnitMeasures
                .SingleAsync(c => c.UnitMeasureCode == request.RequestTarget.UnitMeasureCode, cancellationToken);
            var oldEntity = _mapper.Map<Entities.UnitMeasure, UpdateUnitMeasureCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(UnitMeasure), JsonConvert.SerializeObject(new { request.RequestTarget.UnitMeasureCode }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.UnitMeasures.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.UnitMeasures.SingleAsync(c => c.UnitMeasureCode == request.RequestTarget.UnitMeasureCode, cancellationToken);

            await _mediator.Publish(new UnitMeasureUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.UnitMeasure, UnitMeasureLookupModel>(entity);
        }
    }
}
