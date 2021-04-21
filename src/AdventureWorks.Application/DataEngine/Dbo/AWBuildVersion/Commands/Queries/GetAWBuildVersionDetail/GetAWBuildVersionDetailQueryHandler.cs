using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Dbo.AWBuildVersion.Queries.GetAWBuildVersions;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Dbo.AWBuildVersion.Queries.GetAWBuildVersionDetail
{
    public partial class GetAWBuildVersionDetailQueryHandler : IRequestHandler<GetAWBuildVersionDetailQuery, AWBuildVersionLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetAWBuildVersionDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AWBuildVersionLookupModel> Handle(GetAWBuildVersionDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.AWBuildVersions
                .FindAsync(new object[] { request.SystemInformationID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Dbo.AWBuildVersion, AWBuildVersionLookupModel>(entity);
        }
    }
}
