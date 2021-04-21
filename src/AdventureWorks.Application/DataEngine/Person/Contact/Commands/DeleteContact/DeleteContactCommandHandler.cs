using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Person.Contact.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Person;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Person.Contact.Commands.DeleteContact
{
    public partial class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private ContactsQueryManager _queryManager;

        public DeleteContactCommandHandler(IAdventureWorksContext context, IMediator mediator, ContactsQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Contacts
                .FirstOrDefaultAsync(c => c.ContactID == request.ContactID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.Contact), JsonConvert.SerializeObject(new { request.ContactID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new ContactDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
