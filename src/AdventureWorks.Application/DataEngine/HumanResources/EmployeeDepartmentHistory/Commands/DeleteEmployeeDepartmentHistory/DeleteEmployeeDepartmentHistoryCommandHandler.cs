using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.HumanResources;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Commands.DeleteEmployeeDepartmentHistory
{
    public partial class DeleteEmployeeDepartmentHistoryCommandHandler : IRequestHandler<DeleteEmployeeDepartmentHistoryCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private EmployeeDepartmentHistoriesQueryManager _queryManager;

        public DeleteEmployeeDepartmentHistoryCommandHandler(IAdventureWorksContext context, IMediator mediator, EmployeeDepartmentHistoriesQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteEmployeeDepartmentHistoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.EmployeeDepartmentHistories
                .FirstOrDefaultAsync(c => c.EmployeeID == request.EmployeeID && c.DepartmentID == request.DepartmentID && c.ShiftID == request.ShiftID && c.StartDate == request.StartDate, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.EmployeeDepartmentHistory), JsonConvert.SerializeObject(new { request.EmployeeID, request.DepartmentID, request.ShiftID, request.StartDate }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new EmployeeDepartmentHistoryDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
