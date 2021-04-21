using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Dbo.AWBuildVersion.Queries.GetAWBuildVersions;
using AdventureWorks.Application.DataEngine.Dbo.AWBuildVersion.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Dbo;

namespace AdventureWorks.Application.DataEngine.Dbo.AWBuildVersion.Commands.UpdateAWBuildVersion
{
    public partial class UpdateAWBuildVersionCommandHandler : IRequestHandler<UpdateAWBuildVersionCommand, AWBuildVersionLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly AWBuildVersionsQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateAWBuildVersionCommandHandler(IAdventureWorksContext context,
            AWBuildVersionsQueryManager queryManager,
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

        public async Task<AWBuildVersionLookupModel> Handle(UpdateAWBuildVersionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.AWBuildVersions
                .SingleAsync(c => c.SystemInformationID == request.RequestTarget.SystemInformationID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.AWBuildVersion, UpdateAWBuildVersionCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(AWBuildVersion), JsonConvert.SerializeObject(new { request.RequestTarget.SystemInformationID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.AWBuildVersions.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.AWBuildVersions.SingleAsync(c => c.SystemInformationID == request.RequestTarget.SystemInformationID, cancellationToken);

            await _mediator.Publish(new AWBuildVersionUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.AWBuildVersion, AWBuildVersionLookupModel>(entity);
        }
    }
}
