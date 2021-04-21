using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Queries.GetEmployeePayHistories;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Queries.GetEmployeePayHistoryDetail
{
    public partial class GetEmployeePayHistoryDetailQueryHandler : IRequestHandler<GetEmployeePayHistoryDetailQuery, EmployeePayHistoryLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetEmployeePayHistoryDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EmployeePayHistoryLookupModel> Handle(GetEmployeePayHistoryDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.EmployeePayHistories
                .FindAsync(new object[] { request.EmployeeID, request.RateChangeDate }, cancellationToken);

            return _mapper.Map<Domain.Entities.HumanResources.EmployeePayHistory, EmployeePayHistoryLookupModel>(entity);
        }
    }
}
