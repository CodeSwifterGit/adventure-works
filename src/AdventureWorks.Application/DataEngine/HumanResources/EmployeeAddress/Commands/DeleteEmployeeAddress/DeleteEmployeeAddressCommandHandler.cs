using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.HumanResources;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Commands.DeleteEmployeeAddress
{
    public partial class DeleteEmployeeAddressCommandHandler : IRequestHandler<DeleteEmployeeAddressCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private EmployeeAddressesQueryManager _queryManager;

        public DeleteEmployeeAddressCommandHandler(IAdventureWorksContext context, IMediator mediator, EmployeeAddressesQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteEmployeeAddressCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.EmployeeAddresses
                .FirstOrDefaultAsync(c => c.EmployeeID == request.EmployeeID && c.AddressID == request.AddressID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.EmployeeAddress), JsonConvert.SerializeObject(new { request.EmployeeID, request.AddressID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new EmployeeAddressDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
