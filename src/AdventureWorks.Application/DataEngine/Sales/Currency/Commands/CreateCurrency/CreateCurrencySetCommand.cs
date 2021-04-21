using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.Currency.Queries.GetCurrencies;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.Currency.Commands.CreateCurrency
{
    public partial class CreateCurrencySetCommand : IRequest<List<CurrencyLookupModel>>
    {
        public List<BaseCurrency> Currencies { get; set; }

        public CreateCurrencySetCommand()
        {
        }

        public CreateCurrencySetCommand(List<BaseCurrency> model)
        {
            Currencies = model;
        }

        public partial class Handler : IRequestHandler<CreateCurrencySetCommand, List<CurrencyLookupModel>>
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

            public async Task<List<CurrencyLookupModel>> Handle(CreateCurrencySetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<CurrencyLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.Currencies)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateCurrencyCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}