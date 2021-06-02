using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritory.Queries.GetSalesTerritories;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTerritory.Queries.GetSalesTerritoryDetail
{
    public partial class GetSalesTerritoryDetailQueryHandler : IRequestHandler<GetSalesTerritoryDetailQuery, SalesTerritoryLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetSalesTerritoryDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SalesTerritoryLookupModel> Handle(GetSalesTerritoryDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.SalesTerritories
                .FindAsync(new object[] { request.TerritoryID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Sales.SalesTerritory, SalesTerritoryLookupModel>(entity);
        }
    }
}
