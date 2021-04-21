using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Queries.GetEmployeePayHistories;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.HumanResources;


namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Commands.UpdateEmployeePayHistory
{
    public partial class
        UpdateEmployeePayHistorySetCommandHandler : IRequestHandler<UpdateEmployeePayHistorySetCommand, List<EmployeePayHistoryLookupModel>>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UpdateEmployeePayHistorySetCommandHandler(IAdventureWorksContext context, IMediator mediator, IMapper mapper)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<List<EmployeePayHistoryLookupModel>> Handle(UpdateEmployeePayHistorySetCommand request,
            CancellationToken cancellationToken)
        {
            var result = new List<EmployeePayHistoryLookupModel>();
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