using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Sales.SpecialOffer.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SpecialOffer.Commands.DeleteSpecialOffer
{
    public partial class DeleteSpecialOfferCommandHandler : IRequestHandler<DeleteSpecialOfferCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private SpecialOffersQueryManager _queryManager;

        public DeleteSpecialOfferCommandHandler(IAdventureWorksContext context, IMediator mediator, SpecialOffersQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteSpecialOfferCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.SpecialOffers
                .FirstOrDefaultAsync(c => c.SpecialOfferID == request.SpecialOfferID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.SpecialOffer), JsonConvert.SerializeObject(new { request.SpecialOfferID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new SpecialOfferDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
