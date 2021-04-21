using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Queries.GetVendorContacts;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Queries.GetVendorContactDetail
{
    public partial class GetVendorContactDetailQueryHandler : IRequestHandler<GetVendorContactDetailQuery, VendorContactLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetVendorContactDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VendorContactLookupModel> Handle(GetVendorContactDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.VendorContacts
                .FindAsync(new object[] { request.VendorID, request.ContactID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Purchasing.VendorContact, VendorContactLookupModel>(entity);
        }
    }
}
