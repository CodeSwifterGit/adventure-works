using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.Culture.Queries.GetCultures;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Production.Culture.Queries.GetCultureDetail
{
    public partial class GetCultureDetailQueryHandler : IRequestHandler<GetCultureDetailQuery, CultureLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetCultureDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CultureLookupModel> Handle(GetCultureDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Cultures
                .FindAsync(new object[] { request.CultureID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Production.Culture, CultureLookupModel>(entity);
        }
    }
}
