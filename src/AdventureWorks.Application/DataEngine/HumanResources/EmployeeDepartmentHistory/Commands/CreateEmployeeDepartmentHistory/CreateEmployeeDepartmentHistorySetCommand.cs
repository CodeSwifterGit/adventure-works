using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Queries.GetEmployeeDepartmentHistories;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.HumanResources;


namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Commands.CreateEmployeeDepartmentHistory
{
    public partial class CreateEmployeeDepartmentHistorySetCommand : IRequest<List<EmployeeDepartmentHistoryLookupModel>>
    {
        public List<BaseEmployeeDepartmentHistory> EmployeeDepartmentHistories { get; set; }

        public CreateEmployeeDepartmentHistorySetCommand()
        {
        }

        public CreateEmployeeDepartmentHistorySetCommand(List<BaseEmployeeDepartmentHistory> model)
        {
            EmployeeDepartmentHistories = model;
        }

        public partial class Handler : IRequestHandler<CreateEmployeeDepartmentHistorySetCommand, List<EmployeeDepartmentHistoryLookupModel>>
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

            public async Task<List<EmployeeDepartmentHistoryLookupModel>> Handle(CreateEmployeeDepartmentHistorySetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<EmployeeDepartmentHistoryLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.EmployeeDepartmentHistories)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateEmployeeDepartmentHistoryCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}