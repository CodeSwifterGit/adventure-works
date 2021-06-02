using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SalesReason.Queries.GetSalesReasons;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Sales.SalesReason.Queries.GetSalesReasonDetail
{
    public partial class GetSalesReasonDetailQueryHandler : IRequestHandler<GetSalesReasonDetailQuery, SalesReasonLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetSalesReasonDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SalesReasonLookupModel> Handle(GetSalesReasonDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.SalesReasons
                .FindAsync(new object[] { request.SalesReasonID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Sales.SalesReason, SalesReasonLookupModel>(entity);
        }
    }
}
