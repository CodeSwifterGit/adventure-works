using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Person.AddressType.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Person;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Person.AddressType.Commands.DeleteAddressType
{
    public partial class DeleteAddressTypeCommandHandler : IRequestHandler<DeleteAddressTypeCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private AddressTypesQueryManager _queryManager;

        public DeleteAddressTypeCommandHandler(IAdventureWorksContext context, IMediator mediator, AddressTypesQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteAddressTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.AddressTypes
                .FirstOrDefaultAsync(c => c.AddressTypeID == request.AddressTypeID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.AddressType), JsonConvert.SerializeObject(new { request.AddressTypeID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new AddressTypeDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
