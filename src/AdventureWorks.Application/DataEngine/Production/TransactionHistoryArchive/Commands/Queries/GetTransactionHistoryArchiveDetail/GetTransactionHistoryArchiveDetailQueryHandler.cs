using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.TransactionHistoryArchive.Queries.GetTransactionHistoryArchives;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Production.TransactionHistoryArchive.Queries.GetTransactionHistoryArchiveDetail
{
    public partial class GetTransactionHistoryArchiveDetailQueryHandler : IRequestHandler<GetTransactionHistoryArchiveDetailQuery, TransactionHistoryArchiveLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetTransactionHistoryArchiveDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TransactionHistoryArchiveLookupModel> Handle(GetTransactionHistoryArchiveDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.TransactionHistoryArchives
                .FindAsync(new object[] { request.TransactionID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Production.TransactionHistoryArchive, TransactionHistoryArchiveLookupModel>(entity);
        }
    }
}
