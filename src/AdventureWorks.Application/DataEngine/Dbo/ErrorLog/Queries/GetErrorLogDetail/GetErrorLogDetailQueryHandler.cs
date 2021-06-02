using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Dbo.ErrorLog.Queries.GetErrorLogs;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Dbo.ErrorLog.Queries.GetErrorLogDetail
{
    public partial class GetErrorLogDetailQueryHandler : IRequestHandler<GetErrorLogDetailQuery, ErrorLogLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetErrorLogDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ErrorLogLookupModel> Handle(GetErrorLogDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.ErrorLogs
                .FindAsync(new object[] { request.ErrorLogID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Dbo.ErrorLog, ErrorLogLookupModel>(entity);
        }
    }
}
