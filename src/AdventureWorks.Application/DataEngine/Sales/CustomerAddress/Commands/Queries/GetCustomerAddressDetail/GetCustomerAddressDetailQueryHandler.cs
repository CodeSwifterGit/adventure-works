using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.CustomerAddress.Queries.GetCustomerAddresses;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Sales.CustomerAddress.Queries.GetCustomerAddressDetail
{
    public partial class GetCustomerAddressDetailQueryHandler : IRequestHandler<GetCustomerAddressDetailQuery, CustomerAddressLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetCustomerAddressDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CustomerAddressLookupModel> Handle(GetCustomerAddressDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.CustomerAddresses
                .FindAsync(new object[] { request.CustomerID, request.AddressID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Sales.CustomerAddress, CustomerAddressLookupModel>(entity);
        }
    }
}
