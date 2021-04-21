using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Sales.CreditCard.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.CreditCard.Commands.DeleteCreditCard
{
    public partial class DeleteCreditCardCommandHandler : IRequestHandler<DeleteCreditCardCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private CreditCardsQueryManager _queryManager;

        public DeleteCreditCardCommandHandler(IAdventureWorksContext context, IMediator mediator, CreditCardsQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteCreditCardCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.CreditCards
                .FirstOrDefaultAsync(c => c.CreditCardID == request.CreditCardID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.CreditCard), JsonConvert.SerializeObject(new { request.CreditCardID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new CreditCardDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
