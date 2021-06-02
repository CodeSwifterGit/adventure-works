using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeader.Queries.GetSalesOrderHeaders;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderHeader.Queries.GetSalesOrderHeaderDetail
{
    public partial class GetSalesOrderHeaderDetailQueryHandler : IRequestHandler<GetSalesOrderHeaderDetailQuery, SalesOrderHeaderLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetSalesOrderHeaderDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SalesOrderHeaderLookupModel> Handle(GetSalesOrderHeaderDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.SalesOrderHeaders
                .FindAsync(new object[] { request.SalesOrderID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Sales.SalesOrderHeader, SalesOrderHeaderLookupModel>(entity);
        }
    }
}
