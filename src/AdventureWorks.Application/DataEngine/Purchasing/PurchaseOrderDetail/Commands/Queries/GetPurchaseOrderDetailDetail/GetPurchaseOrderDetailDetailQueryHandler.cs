using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderDetail.Queries.GetPurchaseOrderDetails;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderDetail.Queries.GetPurchaseOrderDetailDetail
{
    public partial class GetPurchaseOrderDetailDetailQueryHandler : IRequestHandler<GetPurchaseOrderDetailDetailQuery, PurchaseOrderDetailLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetPurchaseOrderDetailDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PurchaseOrderDetailLookupModel> Handle(GetPurchaseOrderDetailDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.PurchaseOrderDetails
                .FindAsync(new object[] { request.PurchaseOrderID, request.PurchaseOrderDetailID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Purchasing.PurchaseOrderDetail, PurchaseOrderDetailLookupModel>(entity);
        }
    }
}
