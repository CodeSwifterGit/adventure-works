using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.WorkOrder.Queries.GetWorkOrders;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Production.WorkOrder.Queries.GetWorkOrderDetail
{
    public partial class GetWorkOrderDetailQueryHandler : IRequestHandler<GetWorkOrderDetailQuery, WorkOrderLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetWorkOrderDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<WorkOrderLookupModel> Handle(GetWorkOrderDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.WorkOrders
                .FindAsync(new object[] { request.WorkOrderID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Production.WorkOrder, WorkOrderLookupModel>(entity);
        }
    }
}
