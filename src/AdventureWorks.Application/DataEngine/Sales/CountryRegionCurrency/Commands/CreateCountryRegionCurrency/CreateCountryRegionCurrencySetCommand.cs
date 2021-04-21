using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Queries.GetCountryRegionCurrencies;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Commands.CreateCountryRegionCurrency
{
    public partial class CreateCountryRegionCurrencySetCommand : IRequest<List<CountryRegionCurrencyLookupModel>>
    {
        public List<BaseCountryRegionCurrency> CountryRegionCurrencies { get; set; }

        public CreateCountryRegionCurrencySetCommand()
        {
        }

        public CreateCountryRegionCurrencySetCommand(List<BaseCountryRegionCurrency> model)
        {
            CountryRegionCurrencies = model;
        }

        public partial class Handler : IRequestHandler<CreateCountryRegionCurrencySetCommand, List<CountryRegionCurrencyLookupModel>>
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

            public async Task<List<CountryRegionCurrencyLookupModel>> Handle(CreateCountryRegionCurrencySetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<CountryRegionCurrencyLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.CountryRegionCurrencies)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateCountryRegionCurrencyCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}