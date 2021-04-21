using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.Customer.Queries.GetCustomers;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.Customer.Commands.CreateCustomer
{
    public partial class CreateCustomerSetCommand : IRequest<List<CustomerLookupModel>>
    {
        public List<BaseCustomer> Customers { get; set; }

        public CreateCustomerSetCommand()
        {
        }

        public CreateCustomerSetCommand(List<BaseCustomer> model)
        {
            Customers = model;
        }

        public partial class Handler : IRequestHandler<CreateCustomerSetCommand, List<CustomerLookupModel>>
        {
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;

            public Handler(IAdventureWorksContext context, IMediator mediator, IMapper mapper)
            {
                _context = context;
                _mediator = mediator;
                _mapper = mapper;
            }

            public async Task<List<CustomerLookupModel>> Handle(CreateCustomerSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<CustomerLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.Customers)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateCustomerCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}