using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Queries.GetProductSubcategories;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Queries.GetProductSubcategoryDetail
{
    public partial class GetProductSubcategoryDetailQueryHandler : IRequestHandler<GetProductSubcategoryDetailQuery, ProductSubcategoryLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetProductSubcategoryDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductSubcategoryLookupModel> Handle(GetProductSubcategoryDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductSubcategories
                .FindAsync(new object[] { request.ProductSubcategoryID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Production.ProductSubcategory, ProductSubcategoryLookupModel>(entity);
        }
    }
}
