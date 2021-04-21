using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Commands.DeleteProductModelProductDescriptionCulture
{
    public partial class
        DeleteProductModelProductDescriptionCultureSetCommandHandler : IRequestHandler<DeleteProductModelProductDescriptionCultureSetCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;

        public DeleteProductModelProductDescriptionCultureSetCommandHandler(IAdventureWorksContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(DeleteProductModelProductDescriptionCultureSetCommand requestSet,
            CancellationToken cancellationToken)
        {
            await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
            {
                foreach (var request in requestSet.Commands)
                {
                    await _mediator.Send(
                        new DeleteProductModelProductDescriptionCultureCommand()
                        {
                            ProductModelID = request.ProductModelID,
                            ProductDescriptionID = request.ProductDescriptionID,
                            CultureID = request.CultureID
                        }, cancellationToken);
                }

                await transaction.CommitAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}