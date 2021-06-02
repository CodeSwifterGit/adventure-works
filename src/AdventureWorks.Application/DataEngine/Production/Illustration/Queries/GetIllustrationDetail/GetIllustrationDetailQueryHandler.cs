using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.Illustration.Queries.GetIllustrations;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Production.Illustration.Queries.GetIllustrationDetail
{
    public partial class GetIllustrationDetailQueryHandler : IRequestHandler<GetIllustrationDetailQuery, IllustrationLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetIllustrationDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IllustrationLookupModel> Handle(GetIllustrationDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Illustrations
                .FindAsync(new object[] { request.IllustrationID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Production.Illustration, IllustrationLookupModel>(entity);
        }
    }
}
