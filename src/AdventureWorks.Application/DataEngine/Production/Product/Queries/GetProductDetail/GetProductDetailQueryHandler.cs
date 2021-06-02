using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.Product.Queries.GetProducts;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Production.Product.Queries.GetProductDetail
{
    public partial class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, ProductLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetProductDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductLookupModel> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products
                .FindAsync(new object[] { request.ProductID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Production.Product, ProductLookupModel>(entity);
        }
    }
}
