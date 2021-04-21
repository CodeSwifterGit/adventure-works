using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Dbo.DatabaseLog.Queries.GetDatabaseLogs;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Dbo.DatabaseLog.Queries.GetDatabaseLogDetail
{
    public partial class GetDatabaseLogDetailQueryHandler : IRequestHandler<GetDatabaseLogDetailQuery, DatabaseLogLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetDatabaseLogDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DatabaseLogLookupModel> Handle(GetDatabaseLogDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.DatabaseLogs
                .FindAsync(new object[] { request.DatabaseLogID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Dbo.DatabaseLog, DatabaseLogLookupModel>(entity);
        }
    }
}
