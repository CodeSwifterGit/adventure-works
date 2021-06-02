using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.Store.Queries.GetStores;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Sales.Store.Queries.GetStoreDetail
{
    public partial class GetStoreDetailQueryHandler : IRequestHandler<GetStoreDetailQuery, StoreLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetStoreDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StoreLookupModel> Handle(GetStoreDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Stores
                .FindAsync(new object[] { request.CustomerID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Sales.Store, StoreLookupModel>(entity);
        }
    }
}
