using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Queries.GetProductVendors;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Queries.GetProductVendorDetail
{
    public partial class GetProductVendorDetailQueryHandler : IRequestHandler<GetProductVendorDetailQuery, ProductVendorLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetProductVendorDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductVendorLookupModel> Handle(GetProductVendorDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductVendors
                .FindAsync(new object[] { request.ProductID, request.VendorID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Purchasing.ProductVendor, ProductVendorLookupModel>(entity);
        }
    }
}
