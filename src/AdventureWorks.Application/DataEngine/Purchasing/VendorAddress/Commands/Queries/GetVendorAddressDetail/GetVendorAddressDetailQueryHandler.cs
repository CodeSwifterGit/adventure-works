using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Queries.GetVendorAddresses;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Queries.GetVendorAddressDetail
{
    public partial class GetVendorAddressDetailQueryHandler : IRequestHandler<GetVendorAddressDetailQuery, VendorAddressLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetVendorAddressDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VendorAddressLookupModel> Handle(GetVendorAddressDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.VendorAddresses
                .FindAsync(new object[] { request.VendorID, request.AddressID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Purchasing.VendorAddress, VendorAddressLookupModel>(entity);
        }
    }
}
