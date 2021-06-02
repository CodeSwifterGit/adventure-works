using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.TransactionHistory.Queries.GetTransactionHistories;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Production.TransactionHistory.Queries.GetTransactionHistoryDetail
{
    public partial class GetTransactionHistoryDetailQueryHandler : IRequestHandler<GetTransactionHistoryDetailQuery, TransactionHistoryLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetTransactionHistoryDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TransactionHistoryLookupModel> Handle(GetTransactionHistoryDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.TransactionHistories
                .FindAsync(new object[] { request.TransactionID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Production.TransactionHistory, TransactionHistoryLookupModel>(entity);
        }
    }
}
