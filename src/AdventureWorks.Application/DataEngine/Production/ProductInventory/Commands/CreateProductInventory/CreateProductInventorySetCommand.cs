using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductInventory.Queries.GetProductInventories;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.ProductInventory.Commands.CreateProductInventory
{
    public partial class CreateProductInventorySetCommand : IRequest<List<ProductInventoryLookupModel>>
    {
        public List<BaseProductInventory> ProductInventories { get; set; }

        public CreateProductInventorySetCommand()
        {
        }

        public CreateProductInventorySetCommand(List<BaseProductInventory> model)
        {
            ProductInventories = model;
        }

        public partial class Handler : IRequestHandler<CreateProductInventorySetCommand, List<ProductInventoryLookupModel>>
        {
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;

            public Handler(IAdventureWorksContext context, IMediator mediator, IMapper mapper)
            {
                _context = context;
                _mediator = mediator;
                _mapper = mapper;
            }

            public async Task<List<ProductInventoryLookupModel>> Handle(CreateProductInventorySetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<ProductInventoryLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.ProductInventories)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateProductInventoryCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}