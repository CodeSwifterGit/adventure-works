using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Dbo;


namespace AdventureWorks.Application.DataEngine.Dbo.DatabaseLog.Commands.DeleteDatabaseLog
{
    public partial class
        DeleteDatabaseLogSetCommandHandler : IRequestHandler<DeleteDatabaseLogSetCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;

        public DeleteDatabaseLogSetCommandHandler(IAdventureWorksContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(DeleteDatabaseLogSetCommand requestSet,
            CancellationToken cancellationToken)
        {
            await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
            {
                foreach (var request in requestSet.Commands)
                {
                    await _mediator.Send(
                        new DeleteDatabaseLogCommand()
                        {
                            DatabaseLogID = request.DatabaseLogID
                        }, cancellationToken);
                }

                await transaction.CommitAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}