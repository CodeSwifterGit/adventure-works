using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.CreditCard.Queries.GetCreditCards;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Sales.CreditCard.Queries.GetCreditCardDetail
{
    public partial class GetCreditCardDetailQueryHandler : IRequestHandler<GetCreditCardDetailQuery, CreditCardLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetCreditCardDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreditCardLookupModel> Handle(GetCreditCardDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.CreditCards
                .FindAsync(new object[] { request.CreditCardID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Sales.CreditCard, CreditCardLookupModel>(entity);
        }
    }
}
