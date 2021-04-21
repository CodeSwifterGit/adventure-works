using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Person.CountryRegion.Queries.GetCountryRegions;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Person.CountryRegion.Queries.GetCountryRegionDetail
{
    public partial class GetCountryRegionDetailQueryHandler : IRequestHandler<GetCountryRegionDetailQuery, CountryRegionLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetCountryRegionDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CountryRegionLookupModel> Handle(GetCountryRegionDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.CountryRegions
                .FindAsync(new object[] { request.CountryRegionCode }, cancellationToken);

            return _mapper.Map<Domain.Entities.Person.CountryRegion, CountryRegionLookupModel>(entity);
        }
    }
}
