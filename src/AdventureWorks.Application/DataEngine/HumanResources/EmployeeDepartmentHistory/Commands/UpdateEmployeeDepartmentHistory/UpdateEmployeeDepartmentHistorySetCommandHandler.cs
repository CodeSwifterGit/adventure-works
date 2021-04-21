using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Queries.GetEmployeeDepartmentHistories;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.HumanResources;


namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Commands.UpdateEmployeeDepartmentHistory
{
    public partial class
        UpdateEmployeeDepartmentHistorySetCommandHandler : IRequestHandler<UpdateEmployeeDepartmentHistorySetCommand, List<EmployeeDepartmentHistoryLookupModel>>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UpdateEmployeeDepartmentHistorySetCommandHandler(IAdventureWorksContext context, IMediator mediator, IMapper mapper)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<List<EmployeeDepartmentHistoryLookupModel>> Handle(UpdateEmployeeDepartmentHistorySetCommand request,
            CancellationToken cancellationToken)
        {
            var result = new List<EmployeeDepartmentHistoryLookupModel>();
            await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
            {
                foreach (var singleRequest in request.Commands)
                {
                    var singleUpdateResult = await _mediator.Send(singleRequest, cancellationToken);
                    result.Add(singleUpdateResult);
                }

                await transaction.CommitAsync(cancellationToken);
            }
            return result;
        }
    }
}