using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Person.AddressType.Queries.GetAddressTypes;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Person.AddressType.Queries.GetAddressTypeDetail
{
    public partial class GetAddressTypeDetailQueryHandler : IRequestHandler<GetAddressTypeDetailQuery, AddressTypeLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetAddressTypeDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AddressTypeLookupModel> Handle(GetAddressTypeDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.AddressTypes
                .FindAsync(new object[] { request.AddressTypeID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Person.AddressType, AddressTypeLookupModel>(entity);
        }
    }
}
