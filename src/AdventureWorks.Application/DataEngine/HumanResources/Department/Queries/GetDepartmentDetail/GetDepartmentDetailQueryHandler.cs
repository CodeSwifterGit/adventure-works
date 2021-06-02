using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.HumanResources.Department.Queries.GetDepartments;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.HumanResources.Department.Queries.GetDepartmentDetail
{
    public partial class GetDepartmentDetailQueryHandler : IRequestHandler<GetDepartmentDetailQuery, DepartmentLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetDepartmentDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DepartmentLookupModel> Handle(GetDepartmentDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Departments
                .FindAsync(new object[] { request.DepartmentID }, cancellationToken);

            return _mapper.Map<Domain.Entities.HumanResources.Department, DepartmentLookupModel>(entity);
        }
    }
}
