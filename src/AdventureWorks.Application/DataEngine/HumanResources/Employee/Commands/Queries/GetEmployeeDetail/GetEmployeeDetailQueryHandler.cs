using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.HumanResources.Employee.Queries.GetEmployees;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.HumanResources.Employee.Queries.GetEmployeeDetail
{
    public partial class GetEmployeeDetailQueryHandler : IRequestHandler<GetEmployeeDetailQuery, EmployeeLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetEmployeeDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EmployeeLookupModel> Handle(GetEmployeeDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Employees
                .FindAsync(new object[] { request.EmployeeID }, cancellationToken);

            return _mapper.Map<Domain.Entities.HumanResources.Employee, EmployeeLookupModel>(entity);
        }
    }
}
