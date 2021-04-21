using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.HumanResources.Employee.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.HumanResources;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.HumanResources.Employee.Commands.DeleteEmployee
{
    public partial class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private EmployeesQueryManager _queryManager;

        public DeleteEmployeeCommandHandler(IAdventureWorksContext context, IMediator mediator, EmployeesQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Employees
                .FirstOrDefaultAsync(c => c.EmployeeID == request.EmployeeID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.Employee), JsonConvert.SerializeObject(new { request.EmployeeID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new EmployeeDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
