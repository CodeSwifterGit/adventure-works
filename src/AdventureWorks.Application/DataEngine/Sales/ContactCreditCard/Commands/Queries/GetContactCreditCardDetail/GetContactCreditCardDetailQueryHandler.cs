using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Queries.GetContactCreditCards;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Queries.GetContactCreditCardDetail
{
    public partial class GetContactCreditCardDetailQueryHandler : IRequestHandler<GetContactCreditCardDetailQuery, ContactCreditCardLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetContactCreditCardDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ContactCreditCardLookupModel> Handle(GetContactCreditCardDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.ContactCreditCards
                .FindAsync(new object[] { request.ContactID, request.CreditCardID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Sales.ContactCreditCard, ContactCreditCardLookupModel>(entity);
        }
    }
}
