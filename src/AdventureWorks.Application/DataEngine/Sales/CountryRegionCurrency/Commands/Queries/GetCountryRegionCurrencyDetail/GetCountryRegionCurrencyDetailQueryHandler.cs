using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Queries.GetCountryRegionCurrencies;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Queries.GetCountryRegionCurrencyDetail
{
    public partial class GetCountryRegionCurrencyDetailQueryHandler : IRequestHandler<GetCountryRegionCurrencyDetailQuery, CountryRegionCurrencyLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetCountryRegionCurrencyDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CountryRegionCurrencyLookupModel> Handle(GetCountryRegionCurrencyDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.CountryRegionCurrencies
                .FindAsync(new object[] { request.CountryRegionCode, request.CurrencyCode }, cancellationToken);

            return _mapper.Map<Domain.Entities.Sales.CountryRegionCurrency, CountryRegionCurrencyLookupModel>(entity);
        }
    }
}
