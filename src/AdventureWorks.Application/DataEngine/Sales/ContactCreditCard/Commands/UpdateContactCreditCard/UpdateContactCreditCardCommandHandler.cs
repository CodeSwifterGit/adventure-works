using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Queries.GetContactCreditCards;
using AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Commands.UpdateContactCreditCard
{
    public partial class UpdateContactCreditCardCommandHandler : IRequestHandler<UpdateContactCreditCardCommand, ContactCreditCardLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly ContactCreditCardsQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateContactCreditCardCommandHandler(IAdventureWorksContext context,
            ContactCreditCardsQueryManager queryManager,
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

        public async Task<ContactCreditCardLookupModel> Handle(UpdateContactCreditCardCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ContactCreditCards
                .SingleAsync(c => c.ContactID == request.RequestTarget.ContactID && c.CreditCardID == request.RequestTarget.CreditCardID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.ContactCreditCard, UpdateContactCreditCardCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ContactCreditCard), JsonConvert.SerializeObject(new { request.RequestTarget.ContactID, request.RequestTarget.CreditCardID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.ContactCreditCards.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.ContactCreditCards.SingleAsync(c => c.ContactID == request.RequestTarget.ContactID && c.CreditCardID == request.RequestTarget.CreditCardID, cancellationToken);

            await _mediator.Publish(new ContactCreditCardUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.ContactCreditCard, ContactCreditCardLookupModel>(entity);
        }
    }
}
