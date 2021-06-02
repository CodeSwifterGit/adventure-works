using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.StoreContact.Queries.GetStoreContacts;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Sales.StoreContact.Queries.GetStoreContactDetail
{
    public partial class GetStoreContactDetailQueryHandler : IRequestHandler<GetStoreContactDetailQuery, StoreContactLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetStoreContactDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StoreContactLookupModel> Handle(GetStoreContactDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.StoreContacts
                .FindAsync(new object[] { request.CustomerID, request.ContactID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Sales.StoreContact, StoreContactLookupModel>(entity);
        }
    }
}
