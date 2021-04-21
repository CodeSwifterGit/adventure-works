using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Commands.DeleteContactCreditCard
{
    public partial class DeleteContactCreditCardCommandHandler : IRequestHandler<DeleteContactCreditCardCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private ContactCreditCardsQueryManager _queryManager;

        public DeleteContactCreditCardCommandHandler(IAdventureWorksContext context, IMediator mediator, ContactCreditCardsQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteContactCreditCardCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ContactCreditCards
                .FirstOrDefaultAsync(c => c.ContactID == request.ContactID && c.CreditCardID == request.CreditCardID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.ContactCreditCard), JsonConvert.SerializeObject(new { request.ContactID, request.CreditCardID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new ContactCreditCardDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
