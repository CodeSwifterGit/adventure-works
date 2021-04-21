using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Queries.GetSalesPersonQuotaHistories;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Queries.GetSalesPersonQuotaHistoryDetail
{
    public partial class GetSalesPersonQuotaHistoryDetailQueryHandler : IRequestHandler<GetSalesPersonQuotaHistoryDetailQuery, SalesPersonQuotaHistoryLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetSalesPersonQuotaHistoryDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SalesPersonQuotaHistoryLookupModel> Handle(GetSalesPersonQuotaHistoryDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.SalesPersonQuotaHistories
                .FindAsync(new object[] { request.SalesPersonID, request.QuotaDate }, cancellationToken);

            return _mapper.Map<Domain.Entities.Sales.SalesPersonQuotaHistory, SalesPersonQuotaHistoryLookupModel>(entity);
        }
    }
}
