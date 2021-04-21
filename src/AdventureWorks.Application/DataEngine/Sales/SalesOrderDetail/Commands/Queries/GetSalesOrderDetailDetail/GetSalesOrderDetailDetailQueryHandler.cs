using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Queries.GetSalesOrderDetails;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Queries.GetSalesOrderDetailDetail
{
    public partial class GetSalesOrderDetailDetailQueryHandler : IRequestHandler<GetSalesOrderDetailDetailQuery, SalesOrderDetailLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetSalesOrderDetailDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SalesOrderDetailLookupModel> Handle(GetSalesOrderDetailDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.SalesOrderDetails
                .FindAsync(new object[] { request.SalesOrderID, request.SalesOrderDetailID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Sales.SalesOrderDetail, SalesOrderDetailLookupModel>(entity);
        }
    }
}
