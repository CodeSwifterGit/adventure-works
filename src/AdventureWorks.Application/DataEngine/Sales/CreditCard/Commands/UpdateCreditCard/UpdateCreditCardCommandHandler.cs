using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.CreditCard.Queries.GetCreditCards;
using AdventureWorks.Application.DataEngine.Sales.CreditCard.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.CreditCard.Commands.UpdateCreditCard
{
    public partial class UpdateCreditCardCommandHandler : IRequestHandler<UpdateCreditCardCommand, CreditCardLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly CreditCardsQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateCreditCardCommandHandler(IAdventureWorksContext context,
            CreditCardsQueryManager queryManager,
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

        public async Task<CreditCardLookupModel> Handle(UpdateCreditCardCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.CreditCards
                .SingleAsync(c => c.CreditCardID == request.RequestTarget.CreditCardID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.CreditCard, UpdateCreditCardCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(CreditCard), JsonConvert.SerializeObject(new { request.RequestTarget.CreditCardID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.CreditCards.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.CreditCards.SingleAsync(c => c.CreditCardID == request.RequestTarget.CreditCardID, cancellationToken);

            await _mediator.Publish(new CreditCardUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.CreditCard, CreditCardLookupModel>(entity);
        }
    }
}
