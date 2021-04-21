using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.Illustration.Queries.GetIllustrations;
using AdventureWorks.Application.DataEngine.Production.Illustration.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.Illustration.Commands.UpdateIllustration
{
    public partial class UpdateIllustrationCommandHandler : IRequestHandler<UpdateIllustrationCommand, IllustrationLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IllustrationsQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateIllustrationCommandHandler(IAdventureWorksContext context,
            IllustrationsQueryManager queryManager,
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

        public async Task<IllustrationLookupModel> Handle(UpdateIllustrationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Illustrations
                .SingleAsync(c => c.IllustrationID == request.RequestTarget.IllustrationID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.Illustration, UpdateIllustrationCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Illustration), JsonConvert.SerializeObject(new { request.RequestTarget.IllustrationID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.Illustrations.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.Illustrations.SingleAsync(c => c.IllustrationID == request.RequestTarget.IllustrationID, cancellationToken);

            await _mediator.Publish(new IllustrationUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.Illustration, IllustrationLookupModel>(entity);
        }
    }
}
