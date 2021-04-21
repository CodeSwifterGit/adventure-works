using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritoryHistory.Queries.GetSalesTerritoryHistories;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.SalesTerritoryHistory.Commands.CreateSalesTerritoryHistory
{
    public partial class CreateSalesTerritoryHistorySetCommand : IRequest<List<SalesTerritoryHistoryLookupModel>>
    {
        public List<BaseSalesTerritoryHistory> SalesTerritoryHistories { get; set; }

        public CreateSalesTerritoryHistorySetCommand()
        {
        }

        public CreateSalesTerritoryHistorySetCommand(List<BaseSalesTerritoryHistory> model)
        {
            SalesTerritoryHistories = model;
        }

        public partial class Handler : IRequestHandler<CreateSalesTerritoryHistorySetCommand, List<SalesTerritoryHistoryLookupModel>>
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

            public async Task<List<SalesTerritoryHistoryLookupModel>> Handle(CreateSalesTerritoryHistorySetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<SalesTerritoryHistoryLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.SalesTerritoryHistories)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateSalesTerritoryHistoryCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}