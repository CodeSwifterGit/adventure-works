using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.WorkOrderRouting.Commands.UpdateWorkOrderRouting
{
    public partial class UpdateWorkOrderRoutingCommandValidator : AbstractValidator<UpdateWorkOrderRoutingCommand>
    {
        public UpdateWorkOrderRoutingCommandValidator()
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