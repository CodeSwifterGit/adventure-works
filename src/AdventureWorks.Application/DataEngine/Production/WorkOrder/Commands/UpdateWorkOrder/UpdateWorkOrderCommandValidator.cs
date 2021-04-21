using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.WorkOrder.Commands.UpdateWorkOrder
{
    public partial class UpdateWorkOrderCommandValidator : AbstractValidator<UpdateWorkOrderCommand>
    {
        public UpdateWorkOrderCommandValidator()
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