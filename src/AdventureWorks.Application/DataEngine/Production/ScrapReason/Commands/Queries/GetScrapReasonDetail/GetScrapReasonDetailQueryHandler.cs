using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ScrapReason.Queries.GetScrapReasons;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Production.ScrapReason.Queries.GetScrapReasonDetail
{
    public partial class GetScrapReasonDetailQueryHandler : IRequestHandler<GetScrapReasonDetailQuery, ScrapReasonLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetScrapReasonDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ScrapReasonLookupModel> Handle(GetScrapReasonDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.ScrapReasons
                .FindAsync(new object[] { request.ScrapReasonID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Production.ScrapReason, ScrapReasonLookupModel>(entity);
        }
    }
}
