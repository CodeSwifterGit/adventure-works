using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.Customer.Queries.GetCustomers;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Sales.Customer.Queries.GetCustomerDetail
{
    public partial class GetCustomerDetailQueryHandler : IRequestHandler<GetCustomerDetailQuery, CustomerLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetCustomerDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CustomerLookupModel> Handle(GetCustomerDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Customers
                .FindAsync(new object[] { request.CustomerID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Sales.Customer, CustomerLookupModel>(entity);
        }
    }
}
