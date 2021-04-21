using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.CustomerAddress.Queries.GetCustomerAddresses;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.CustomerAddress.Commands.CreateCustomerAddress
{
    public partial class CreateCustomerAddressSetCommand : IRequest<List<CustomerAddressLookupModel>>
    {
        public List<BaseCustomerAddress> CustomerAddresses { get; set; }

        public CreateCustomerAddressSetCommand()
        {
        }

        public CreateCustomerAddressSetCommand(List<BaseCustomerAddress> model)
        {
            CustomerAddresses = model;
        }

        public partial class Handler : IRequestHandler<CreateCustomerAddressSetCommand, List<CustomerAddressLookupModel>>
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

            public async Task<List<CustomerAddressLookupModel>> Handle(CreateCustomerAddressSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<CustomerAddressLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.CustomerAddresses)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateCustomerAddressCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}