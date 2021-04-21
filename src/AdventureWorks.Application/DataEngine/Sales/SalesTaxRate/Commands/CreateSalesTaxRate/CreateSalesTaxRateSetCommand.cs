using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SalesTaxRate.Queries.GetSalesTaxRates;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.SalesTaxRate.Commands.CreateSalesTaxRate
{
    public partial class CreateSalesTaxRateSetCommand : IRequest<List<SalesTaxRateLookupModel>>
    {
        public List<BaseSalesTaxRate> SalesTaxRates { get; set; }

        public CreateSalesTaxRateSetCommand()
        {
        }

        public CreateSalesTaxRateSetCommand(List<BaseSalesTaxRate> model)
        {
            SalesTaxRates = model;
        }

        public partial class Handler : IRequestHandler<CreateSalesTaxRateSetCommand, List<SalesTaxRateLookupModel>>
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

            public async Task<List<SalesTaxRateLookupModel>> Handle(CreateSalesTaxRateSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<SalesTaxRateLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.SalesTaxRates)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateSalesTaxRateCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}