using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.WorkOrderRouting.Queries.GetWorkOrderRoutings;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Production.WorkOrderRouting.Queries.GetWorkOrderRoutingDetail
{
    public partial class GetWorkOrderRoutingDetailQueryHandler : IRequestHandler<GetWorkOrderRoutingDetailQuery, WorkOrderRoutingLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetWorkOrderRoutingDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<WorkOrderRoutingLookupModel> Handle(GetWorkOrderRoutingDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.WorkOrderRoutings
                .FindAsync(new object[] { request.WorkOrderID, request.ProductID, request.OperationSequence }, cancellationToken);

            return _mapper.Map<Domain.Entities.Production.WorkOrderRouting, WorkOrderRoutingLookupModel>(entity);
        }
    }
}
