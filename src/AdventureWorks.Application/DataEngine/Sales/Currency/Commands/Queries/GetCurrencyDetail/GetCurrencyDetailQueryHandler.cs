using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.Currency.Queries.GetCurrencies;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Sales.Currency.Queries.GetCurrencyDetail
{
    public partial class GetCurrencyDetailQueryHandler : IRequestHandler<GetCurrencyDetailQuery, CurrencyLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetCurrencyDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CurrencyLookupModel> Handle(GetCurrencyDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Currencies
                .FindAsync(new object[] { request.CurrencyCode }, cancellationToken);

            return _mapper.Map<Domain.Entities.Sales.Currency, CurrencyLookupModel>(entity);
        }
    }
}
