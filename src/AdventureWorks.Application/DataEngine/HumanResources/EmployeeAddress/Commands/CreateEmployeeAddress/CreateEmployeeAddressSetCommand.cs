using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Queries.GetEmployeeAddresses;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.HumanResources;


namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Commands.CreateEmployeeAddress
{
    public partial class CreateEmployeeAddressSetCommand : IRequest<List<EmployeeAddressLookupModel>>
    {
        public List<BaseEmployeeAddress> EmployeeAddresses { get; set; }

        public CreateEmployeeAddressSetCommand()
        {
        }

        public CreateEmployeeAddressSetCommand(List<BaseEmployeeAddress> model)
        {
            EmployeeAddresses = model;
        }

        public partial class Handler : IRequestHandler<CreateEmployeeAddressSetCommand, List<EmployeeAddressLookupModel>>
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

            public async Task<List<EmployeeAddressLookupModel>> Handle(CreateEmployeeAddressSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<EmployeeAddressLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.EmployeeAddresses)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateEmployeeAddressCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}