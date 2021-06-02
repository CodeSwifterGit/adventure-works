using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductCategory.Queries.GetProductCategories;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Production.ProductCategory.Queries.GetProductCategoryDetail
{
    public partial class GetProductCategoryDetailQueryHandler : IRequestHandler<GetProductCategoryDetailQuery, ProductCategoryLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetProductCategoryDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductCategoryLookupModel> Handle(GetProductCategoryDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductCategories
                .FindAsync(new object[] { request.ProductCategoryID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Production.ProductCategory, ProductCategoryLookupModel>(entity);
        }
    }
}
