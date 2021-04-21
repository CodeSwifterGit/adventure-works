using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Sales.Individual.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.Individual.Commands.DeleteIndividual
{
    public partial class DeleteIndividualCommandHandler : IRequestHandler<DeleteIndividualCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private IndividualsQueryManager _queryManager;

        public DeleteIndividualCommandHandler(IAdventureWorksContext context, IMediator mediator, IndividualsQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteIndividualCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Individuals
                .FirstOrDefaultAsync(c => c.CustomerID == request.CustomerID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.Individual), JsonConvert.SerializeObject(new { request.CustomerID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new IndividualDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
