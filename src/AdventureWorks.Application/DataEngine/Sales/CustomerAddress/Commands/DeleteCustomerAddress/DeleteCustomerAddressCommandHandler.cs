using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Sales.CustomerAddress.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.CustomerAddress.Commands.DeleteCustomerAddress
{
    public partial class DeleteCustomerAddressCommandHandler : IRequestHandler<DeleteCustomerAddressCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private CustomerAddressesQueryManager _queryManager;

        public DeleteCustomerAddressCommandHandler(IAdventureWorksContext context, IMediator mediator, CustomerAddressesQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteCustomerAddressCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.CustomerAddresses
                .FirstOrDefaultAsync(c => c.CustomerID == request.CustomerID && c.AddressID == request.AddressID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.CustomerAddress), JsonConvert.SerializeObject(new { request.CustomerID, request.AddressID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new CustomerAddressDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
