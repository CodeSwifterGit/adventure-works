using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Queries.GetSalesOrderHeaderSalesReasons;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Queries.GetSalesOrderHeaderSalesReasonDetail
{
    public partial class GetSalesOrderHeaderSalesReasonDetailQueryHandler : IRequestHandler<GetSalesOrderHeaderSalesReasonDetailQuery, SalesOrderHeaderSalesReasonLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetSalesOrderHeaderSalesReasonDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SalesOrderHeaderSalesReasonLookupModel> Handle(GetSalesOrderHeaderSalesReasonDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.SalesOrderHeaderSalesReasons
                .FindAsync(new object[] { request.SalesOrderID, request.SalesReasonID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Sales.SalesOrderHeaderSalesReason, SalesOrderHeaderSalesReasonLookupModel>(entity);
        }
    }
}
