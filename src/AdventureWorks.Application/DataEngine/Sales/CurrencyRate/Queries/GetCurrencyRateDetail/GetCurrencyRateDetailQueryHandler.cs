using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.CurrencyRate.Queries.GetCurrencyRates;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Sales.CurrencyRate.Queries.GetCurrencyRateDetail
{
    public partial class GetCurrencyRateDetailQueryHandler : IRequestHandler<GetCurrencyRateDetailQuery, CurrencyRateLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetCurrencyRateDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CurrencyRateLookupModel> Handle(GetCurrencyRateDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.CurrencyRates
                .FindAsync(new object[] { request.CurrencyRateID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Sales.CurrencyRate, CurrencyRateLookupModel>(entity);
        }
    }
}
