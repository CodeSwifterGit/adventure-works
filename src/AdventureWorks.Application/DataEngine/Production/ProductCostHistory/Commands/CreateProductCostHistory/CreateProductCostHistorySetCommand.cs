using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductCostHistory.Queries.GetProductCostHistories;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.ProductCostHistory.Commands.CreateProductCostHistory
{
    public partial class CreateProductCostHistorySetCommand : IRequest<List<ProductCostHistoryLookupModel>>
    {
        public List<BaseProductCostHistory> ProductCostHistories { get; set; }

        public CreateProductCostHistorySetCommand()
        {
        }

        public CreateProductCostHistorySetCommand(List<BaseProductCostHistory> model)
        {
            ProductCostHistories = model;
        }

        public partial class Handler : IRequestHandler<CreateProductCostHistorySetCommand, List<ProductCostHistoryLookupModel>>
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

            public async Task<List<ProductCostHistoryLookupModel>> Handle(CreateProductCostHistorySetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<ProductCostHistoryLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.ProductCostHistories)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateProductCostHistoryCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}