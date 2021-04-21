using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.HumanResources.Employee.Queries.GetEmployees;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.HumanResources;


namespace AdventureWorks.Application.DataEngine.HumanResources.Employee.Commands.CreateEmployee
{
    public partial class CreateEmployeeSetCommand : IRequest<List<EmployeeLookupModel>>
    {
        public List<BaseEmployee> Employees { get; set; }

        public CreateEmployeeSetCommand()
        {
        }

        public CreateEmployeeSetCommand(List<BaseEmployee> model)
        {
            Employees = model;
        }

        public partial class Handler : IRequestHandler<CreateEmployeeSetCommand, List<EmployeeLookupModel>>
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

            public async Task<List<EmployeeLookupModel>> Handle(CreateEmployeeSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<EmployeeLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.Employees)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateEmployeeCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}