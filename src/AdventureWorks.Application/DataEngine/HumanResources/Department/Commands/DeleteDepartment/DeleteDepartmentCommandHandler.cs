using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.HumanResources.Department.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.HumanResources;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.HumanResources.Department.Commands.DeleteDepartment
{
    public partial class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private DepartmentsQueryManager _queryManager;

        public DeleteDepartmentCommandHandler(IAdventureWorksContext context, IMediator mediator, DepartmentsQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Departments
                .FirstOrDefaultAsync(c => c.DepartmentID == request.DepartmentID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.Department), JsonConvert.SerializeObject(new { request.DepartmentID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new DepartmentDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
