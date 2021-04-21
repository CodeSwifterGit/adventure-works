using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.WorkOrder.Commands.DeleteWorkOrder
{
    public partial class DeleteWorkOrderCommandValidator : AbstractValidator<DeleteWorkOrderCommand>
    {
        public DeleteWorkOrderCommandValidator()
        {
            RuleFor(v => v.WorkOrderID).NotEmpty();
        }
    }
}
