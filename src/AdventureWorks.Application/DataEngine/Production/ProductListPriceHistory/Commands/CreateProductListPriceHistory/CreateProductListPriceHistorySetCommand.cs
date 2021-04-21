using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductListPriceHistory.Queries.GetProductListPriceHistories;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.ProductListPriceHistory.Commands.CreateProductListPriceHistory
{
    public partial class CreateProductListPriceHistorySetCommand : IRequest<List<ProductListPriceHistoryLookupModel>>
    {
        public List<BaseProductListPriceHistory> ProductListPriceHistories { get; set; }

        public CreateProductListPriceHistorySetCommand()
        {
        }

        public CreateProductListPriceHistorySetCommand(List<BaseProductListPriceHistory> model)
        {
            ProductListPriceHistories = model;
        }

        public partial class Handler : IRequestHandler<CreateProductListPriceHistorySetCommand, List<ProductListPriceHistoryLookupModel>>
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

            public async Task<List<ProductListPriceHistoryLookupModel>> Handle(CreateProductListPriceHistorySetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<ProductListPriceHistoryLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.ProductListPriceHistories)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateProductListPriceHistoryCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}