using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritory.Queries.GetSalesTerritories;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.SalesTerritory.Commands.CreateSalesTerritory
{
    public partial class CreateSalesTerritorySetCommand : IRequest<List<SalesTerritoryLookupModel>>
    {
        public List<BaseSalesTerritory> SalesTerritories { get; set; }

        public CreateSalesTerritorySetCommand()
        {
        }

        public CreateSalesTerritorySetCommand(List<BaseSalesTerritory> model)
        {
            SalesTerritories = model;
        }

        public partial class Handler : IRequestHandler<CreateSalesTerritorySetCommand, List<SalesTerritoryLookupModel>>
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

            public async Task<List<SalesTerritoryLookupModel>> Handle(CreateSalesTerritorySetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<SalesTerritoryLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.SalesTerritories)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateSalesTerritoryCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}