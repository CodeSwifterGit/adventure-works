using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.HumanResources;


namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Commands.DeleteEmployeeDepartmentHistory
{
    public partial class
        DeleteEmployeeDepartmentHistorySetCommandHandler : IRequestHandler<DeleteEmployeeDepartmentHistorySetCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;

        public DeleteEmployeeDepartmentHistorySetCommandHandler(IAdventureWorksContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(DeleteEmployeeDepartmentHistorySetCommand requestSet,
            CancellationToken cancellationToken)
        {
            await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
            {
                foreach (var request in requestSet.Commands)
                {
                    await _mediator.Send(
                        new DeleteEmployeeDepartmentHistoryCommand()
                        {
                            EmployeeID = request.EmployeeID,
                            DepartmentID = request.DepartmentID,
                            ShiftID = request.ShiftID,
                            StartDate = request.StartDate
                        }, cancellationToken);
                }

                await transaction.CommitAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}