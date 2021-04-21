using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.WorkOrderRouting.Commands.CreateWorkOrderRouting
{
    public partial class CreateWorkOrderRoutingCommandValidator : AbstractValidator<CreateWorkOrderRoutingCommand>
    {
        public CreateWorkOrderRoutingCommandValidator()
        {
            RuleFor(v => v.WorkOrderID).NotEmpty();
            RuleFor(v => v.ProductID).NotEmpty();
            RuleFor(v => v.OperationSequence).NotEmpty();
            RuleFor(v => v.LocationID).NotEmpty();
            RuleFor(v => v.ScheduledStartDate).NotEmpty();
            RuleFor(v => v.ScheduledEndDate).NotEmpty();
            RuleFor(v => v.ActualStartDate).NotEmpty();
            RuleFor(v => v.ActualEndDate).NotEmpty();
            RuleFor(v => v.ActualResourceHrs).NotEmpty();
            RuleFor(v => v.PlannedCost).NotEmpty();
            RuleFor(v => v.ActualCost).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}