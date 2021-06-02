using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.Location.Queries.GetLocations;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Production.Location.Queries.GetLocationDetail
{
    public partial class GetLocationDetailQueryHandler : IRequestHandler<GetLocationDetailQuery, LocationLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetLocationDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LocationLookupModel> Handle(GetLocationDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Locations
                .FindAsync(new object[] { request.LocationID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Production.Location, LocationLookupModel>(entity);
        }
    }
}
