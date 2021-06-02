using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SpecialOfferProduct.Queries.GetSpecialOfferProducts;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Sales.SpecialOfferProduct.Queries.GetSpecialOfferProductDetail
{
    public partial class GetSpecialOfferProductDetailQueryHandler : IRequestHandler<GetSpecialOfferProductDetailQuery, SpecialOfferProductLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetSpecialOfferProductDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SpecialOfferProductLookupModel> Handle(GetSpecialOfferProductDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.SpecialOfferProducts
                .FindAsync(new object[] { request.SpecialOfferID, request.ProductID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Sales.SpecialOfferProduct, SpecialOfferProductLookupModel>(entity);
        }
    }
}
