using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SalesPerson.Queries.GetSalesPeople;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Sales.SalesPerson.Queries.GetSalesPersonDetail
{
    public partial class GetSalesPersonDetailQueryHandler : IRequestHandler<GetSalesPersonDetailQuery, SalesPersonLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetSalesPersonDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SalesPersonLookupModel> Handle(GetSalesPersonDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.SalesPeople
                .FindAsync(new object[] { request.SalesPersonID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Sales.SalesPerson, SalesPersonLookupModel>(entity);
        }
    }
}
