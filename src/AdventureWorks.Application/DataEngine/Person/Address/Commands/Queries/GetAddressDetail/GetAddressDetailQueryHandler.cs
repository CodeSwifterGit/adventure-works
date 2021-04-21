using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Person.Address.Queries.GetAddresses;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Person.Address.Queries.GetAddressDetail
{
    public partial class GetAddressDetailQueryHandler : IRequestHandler<GetAddressDetailQuery, AddressLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetAddressDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AddressLookupModel> Handle(GetAddressDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Addresses
                .FindAsync(new object[] { request.AddressID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Person.Address, AddressLookupModel>(entity);
        }
    }
}
