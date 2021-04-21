using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Queries.GetEmployeePayHistories;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.HumanResources;


namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Commands.CreateEmployeePayHistory
{
    public partial class CreateEmployeePayHistorySetCommand : IRequest<List<EmployeePayHistoryLookupModel>>
    {
        public List<BaseEmployeePayHistory> EmployeePayHistories { get; set; }

        public CreateEmployeePayHistorySetCommand()
        {
        }

        public CreateEmployeePayHistorySetCommand(List<BaseEmployeePayHistory> model)
        {
            EmployeePayHistories = model;
        }

        public partial class Handler : IRequestHandler<CreateEmployeePayHistorySetCommand, List<EmployeePayHistoryLookupModel>>
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

            public async Task<List<EmployeePayHistoryLookupModel>> Handle(CreateEmployeePayHistorySetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<EmployeePayHistoryLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.EmployeePayHistories)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateEmployeePayHistoryCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}