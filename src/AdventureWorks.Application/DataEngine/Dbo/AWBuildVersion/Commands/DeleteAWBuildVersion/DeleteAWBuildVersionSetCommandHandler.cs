using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Dbo;


namespace AdventureWorks.Application.DataEngine.Dbo.AWBuildVersion.Commands.DeleteAWBuildVersion
{
    public partial class
        DeleteAWBuildVersionSetCommandHandler : IRequestHandler<DeleteAWBuildVersionSetCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;

        public DeleteAWBuildVersionSetCommandHandler(IAdventureWorksContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(DeleteAWBuildVersionSetCommand requestSet,
            CancellationToken cancellationToken)
        {
            await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
            {
                foreach (var request in requestSet.Commands)
                {
                    await _mediator.Send(
                        new DeleteAWBuildVersionCommand()
                        {
                            SystemInformationID = request.SystemInformationID
                        }, cancellationToken);
                }

                await transaction.CommitAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}