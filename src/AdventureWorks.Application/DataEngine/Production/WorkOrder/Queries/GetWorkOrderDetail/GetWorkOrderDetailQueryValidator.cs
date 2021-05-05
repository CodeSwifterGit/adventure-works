using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.WorkOrder.Queries.GetWorkOrderDetail
{
    public partial class GetWorkOrderDetailQueryValidator : AbstractValidator<GetWorkOrderDetailQuery>
    {
        public GetWorkOrderDetailQueryValidator()
        {
            RuleFor(v => v.WorkOrderID).NotEmpty();
        }
    }
}
