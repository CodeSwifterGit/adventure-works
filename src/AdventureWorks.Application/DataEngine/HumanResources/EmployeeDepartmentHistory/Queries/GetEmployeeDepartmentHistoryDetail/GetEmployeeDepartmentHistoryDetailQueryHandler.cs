using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Queries.GetEmployeeDepartmentHistories;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Queries.GetEmployeeDepartmentHistoryDetail
{
    public partial class GetEmployeeDepartmentHistoryDetailQueryHandler : IRequestHandler<GetEmployeeDepartmentHistoryDetailQuery, EmployeeDepartmentHistoryLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetEmployeeDepartmentHistoryDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EmployeeDepartmentHistoryLookupModel> Handle(GetEmployeeDepartmentHistoryDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.EmployeeDepartmentHistories
                .FindAsync(new object[] { request.EmployeeID, request.DepartmentID, request.ShiftID, request.StartDate }, cancellationToken);

            return _mapper.Map<Domain.Entities.HumanResources.EmployeeDepartmentHistory, EmployeeDepartmentHistoryLookupModel>(entity);
        }
    }
}
