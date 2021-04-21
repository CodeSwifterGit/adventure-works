using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.WorkOrder.Commands.CreateWorkOrder
{
    public partial class CreateWorkOrderCommandValidator : AbstractValidator<CreateWorkOrderCommand>
    {
        public CreateWorkOrderCommandValidator()
        {
            RuleFor(v => v.WorkOrderID).NotEmpty();
            RuleFor(v => v.ProductID).NotEmpty();
            RuleFor(v => v.OrderQty).NotEmpty();
            RuleFor(v => v.StockedQty).NotEmpty();
            RuleFor(v => v.ScrappedQty).NotEmpty();
            RuleFor(v => v.StartDate).NotEmpty();
            RuleFor(v => v.EndDate).NotEmpty();
            RuleFor(v => v.DueDate).NotEmpty();
            RuleFor(v => v.ScrapReasonID).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}