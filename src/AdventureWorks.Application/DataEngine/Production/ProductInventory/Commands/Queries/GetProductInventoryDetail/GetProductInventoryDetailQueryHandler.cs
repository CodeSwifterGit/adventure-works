using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductInventory.Queries.GetProductInventories;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Production.ProductInventory.Queries.GetProductInventoryDetail
{
    public partial class GetProductInventoryDetailQueryHandler : IRequestHandler<GetProductInventoryDetailQuery, ProductInventoryLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetProductInventoryDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductInventoryLookupModel> Handle(GetProductInventoryDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductInventories
                .FindAsync(new object[] { request.ProductID, request.LocationID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Production.ProductInventory, ProductInventoryLookupModel>(entity);
        }
    }
}
