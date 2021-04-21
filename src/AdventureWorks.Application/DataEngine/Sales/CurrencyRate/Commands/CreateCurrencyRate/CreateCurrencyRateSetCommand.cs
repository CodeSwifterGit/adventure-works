using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.CurrencyRate.Queries.GetCurrencyRates;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.CurrencyRate.Commands.CreateCurrencyRate
{
    public partial class CreateCurrencyRateSetCommand : IRequest<List<CurrencyRateLookupModel>>
    {
        public List<BaseCurrencyRate> CurrencyRates { get; set; }

        public CreateCurrencyRateSetCommand()
        {
        }

        public CreateCurrencyRateSetCommand(List<BaseCurrencyRate> model)
        {
            CurrencyRates = model;
        }

        public partial class Handler : IRequestHandler<CreateCurrencyRateSetCommand, List<CurrencyRateLookupModel>>
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

            public async Task<List<CurrencyRateLookupModel>> Handle(CreateCurrencyRateSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<CurrencyRateLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.CurrencyRates)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateCurrencyRateCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}