using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Purchasing.ShipMethod.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Purchasing;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Purchasing.ShipMethod.Commands.DeleteShipMethod
{
    public partial class DeleteShipMethodCommandHandler : IRequestHandler<DeleteShipMethodCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private ShipMethodsQueryManager _queryManager;

        public DeleteShipMethodCommandHandler(IAdventureWorksContext context, IMediator mediator, ShipMethodsQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteShipMethodCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ShipMethods
                .FirstOrDefaultAsync(c => c.ShipMethodID == request.ShipMethodID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.ShipMethod), JsonConvert.SerializeObject(new { request.ShipMethodID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new ShipMethodDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
