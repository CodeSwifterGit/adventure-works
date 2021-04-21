using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderHeader.Queries.GetPurchaseOrderHeaders;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderHeader.Queries.GetPurchaseOrderHeaderDetail
{
    public partial class GetPurchaseOrderHeaderDetailQueryHandler : IRequestHandler<GetPurchaseOrderHeaderDetailQuery, PurchaseOrderHeaderLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetPurchaseOrderHeaderDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PurchaseOrderHeaderLookupModel> Handle(GetPurchaseOrderHeaderDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.PurchaseOrderHeaders
                .FindAsync(new object[] { request.PurchaseOrderID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Purchasing.PurchaseOrderHeader, PurchaseOrderHeaderLookupModel>(entity);
        }
    }
}
