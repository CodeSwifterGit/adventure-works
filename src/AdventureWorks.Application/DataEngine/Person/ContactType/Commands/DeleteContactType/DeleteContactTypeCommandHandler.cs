using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Person.ContactType.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Person;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Person.ContactType.Commands.DeleteContactType
{
    public partial class DeleteContactTypeCommandHandler : IRequestHandler<DeleteContactTypeCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private ContactTypesQueryManager _queryManager;

        public DeleteContactTypeCommandHandler(IAdventureWorksContext context, IMediator mediator, ContactTypesQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteContactTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ContactTypes
                .FirstOrDefaultAsync(c => c.ContactTypeID == request.ContactTypeID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.ContactType), JsonConvert.SerializeObject(new { request.ContactTypeID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new ContactTypeDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
