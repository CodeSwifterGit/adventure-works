using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SpecialOffer.Queries.GetSpecialOffers;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Sales.SpecialOffer.Queries.GetSpecialOfferDetail
{
    public partial class GetSpecialOfferDetailQueryHandler : IRequestHandler<GetSpecialOfferDetailQuery, SpecialOfferLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetSpecialOfferDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SpecialOfferLookupModel> Handle(GetSpecialOfferDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.SpecialOffers
                .FindAsync(new object[] { request.SpecialOfferID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Sales.SpecialOffer, SpecialOfferLookupModel>(entity);
        }
    }
}
