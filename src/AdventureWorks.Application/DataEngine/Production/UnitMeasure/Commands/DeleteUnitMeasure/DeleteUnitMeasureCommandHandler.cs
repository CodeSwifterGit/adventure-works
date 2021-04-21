using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Production.UnitMeasure.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.UnitMeasure.Commands.DeleteUnitMeasure
{
    public partial class DeleteUnitMeasureCommandHandler : IRequestHandler<DeleteUnitMeasureCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private UnitMeasuresQueryManager _queryManager;

        public DeleteUnitMeasureCommandHandler(IAdventureWorksContext context, IMediator mediator, UnitMeasuresQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteUnitMeasureCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.UnitMeasures
                .FirstOrDefaultAsync(c => c.UnitMeasureCode == request.UnitMeasureCode, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.UnitMeasure), JsonConvert.SerializeObject(new { request.UnitMeasureCode }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new UnitMeasureDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
