using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Person;


namespace AdventureWorks.Application.DataEngine.Person.Contact.Commands.DeleteContact
{
    public partial class
        DeleteContactSetCommandHandler : IRequestHandler<DeleteContactSetCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;

        public DeleteContactSetCommandHandler(IAdventureWorksContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(DeleteContactSetCommand requestSet,
            CancellationToken cancellationToken)
        {
            await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
            {
                foreach (var request in requestSet.Commands)
                {
                    await _mediator.Send(
                        new DeleteContactCommand()
                        {
                            ContactID = request.ContactID
                        }, cancellationToken);
                }

                await transaction.CommitAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}