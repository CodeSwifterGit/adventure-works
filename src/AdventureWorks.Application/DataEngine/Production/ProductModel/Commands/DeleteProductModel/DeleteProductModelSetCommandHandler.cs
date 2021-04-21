using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.ProductModel.Commands.DeleteProductModel
{
    public partial class
        DeleteProductModelSetCommandHandler : IRequestHandler<DeleteProductModelSetCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;

        public DeleteProductModelSetCommandHandler(IAdventureWorksContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(DeleteProductModelSetCommand requestSet,
            CancellationToken cancellationToken)
        {
            await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
            {
                foreach (var request in requestSet.Commands)
                {
                    await _mediator.Send(
                        new DeleteProductModelCommand()
                        {
                            ProductModelID = request.ProductModelID
                        }, cancellationToken);
                }

                await transaction.CommitAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}