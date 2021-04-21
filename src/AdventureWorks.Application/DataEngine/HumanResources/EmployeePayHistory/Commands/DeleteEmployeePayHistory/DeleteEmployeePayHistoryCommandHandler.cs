using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.HumanResources;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Commands.DeleteEmployeePayHistory
{
    public partial class DeleteEmployeePayHistoryCommandHandler : IRequestHandler<DeleteEmployeePayHistoryCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private EmployeePayHistoriesQueryManager _queryManager;

        public DeleteEmployeePayHistoryCommandHandler(IAdventureWorksContext context, IMediator mediator, EmployeePayHistoriesQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteEmployeePayHistoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.EmployeePayHistories
                .FirstOrDefaultAsync(c => c.EmployeeID == request.EmployeeID && c.RateChangeDate == request.RateChangeDate, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.EmployeePayHistory), JsonConvert.SerializeObject(new { request.EmployeeID, request.RateChangeDate }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new EmployeePayHistoryDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
