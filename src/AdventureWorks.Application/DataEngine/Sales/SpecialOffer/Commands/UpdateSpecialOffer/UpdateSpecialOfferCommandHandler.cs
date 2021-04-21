using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SpecialOffer.Queries.GetSpecialOffers;
using AdventureWorks.Application.DataEngine.Sales.SpecialOffer.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.SpecialOffer.Commands.UpdateSpecialOffer
{
    public partial class UpdateSpecialOfferCommandHandler : IRequestHandler<UpdateSpecialOfferCommand, SpecialOfferLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly SpecialOffersQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateSpecialOfferCommandHandler(IAdventureWorksContext context,
            SpecialOffersQueryManager queryManager,
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

        public async Task<SpecialOfferLookupModel> Handle(UpdateSpecialOfferCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.SpecialOffers
                .SingleAsync(c => c.SpecialOfferID == request.RequestTarget.SpecialOfferID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.SpecialOffer, UpdateSpecialOfferCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(SpecialOffer), JsonConvert.SerializeObject(new { request.RequestTarget.SpecialOfferID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.SpecialOffers.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.SpecialOffers.SingleAsync(c => c.SpecialOfferID == request.RequestTarget.SpecialOfferID, cancellationToken);

            await _mediator.Publish(new SpecialOfferUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.SpecialOffer, SpecialOfferLookupModel>(entity);
        }
    }
}
