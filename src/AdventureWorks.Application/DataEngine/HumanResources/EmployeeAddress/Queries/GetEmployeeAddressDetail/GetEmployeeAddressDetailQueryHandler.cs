using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Queries.GetEmployeeAddresses;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Queries.GetEmployeeAddressDetail
{
    public partial class GetEmployeeAddressDetailQueryHandler : IRequestHandler<GetEmployeeAddressDetailQuery, EmployeeAddressLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetEmployeeAddressDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EmployeeAddressLookupModel> Handle(GetEmployeeAddressDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.EmployeeAddresses
                .FindAsync(new object[] { request.EmployeeID, request.AddressID }, cancellationToken);

            return _mapper.Map<Domain.Entities.HumanResources.EmployeeAddress, EmployeeAddressLookupModel>(entity);
        }
    }
}
