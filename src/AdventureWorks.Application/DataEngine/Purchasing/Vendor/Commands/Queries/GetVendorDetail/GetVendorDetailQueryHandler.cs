using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Purchasing.Vendor.Queries.GetVendors;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Purchasing.Vendor.Queries.GetVendorDetail
{
    public partial class GetVendorDetailQueryHandler : IRequestHandler<GetVendorDetailQuery, VendorLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetVendorDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VendorLookupModel> Handle(GetVendorDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Vendors
                .FindAsync(new object[] { request.VendorID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Purchasing.Vendor, VendorLookupModel>(entity);
        }
    }
}
