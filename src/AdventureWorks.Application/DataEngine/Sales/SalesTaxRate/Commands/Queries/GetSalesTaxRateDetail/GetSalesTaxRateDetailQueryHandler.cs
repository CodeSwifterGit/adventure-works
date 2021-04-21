using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SalesTaxRate.Queries.GetSalesTaxRates;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTaxRate.Queries.GetSalesTaxRateDetail
{
    public partial class GetSalesTaxRateDetailQueryHandler : IRequestHandler<GetSalesTaxRateDetailQuery, SalesTaxRateLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetSalesTaxRateDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SalesTaxRateLookupModel> Handle(GetSalesTaxRateDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.SalesTaxRates
                .FindAsync(new object[] { request.SalesTaxRateID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Sales.SalesTaxRate, SalesTaxRateLookupModel>(entity);
        }
    }
}
