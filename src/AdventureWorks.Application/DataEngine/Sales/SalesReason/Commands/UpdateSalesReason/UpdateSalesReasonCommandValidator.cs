using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesReason.Commands.UpdateSalesReason
{
    public partial class UpdateSalesReasonCommandValidator : AbstractValidator<UpdateSalesReasonCommand>
    {
        public UpdateSalesReasonCommandValidator()
        {
            RuleFor(v => v.SalesReasonID).NotEmpty();
            RuleFor(v => v.Name).NotEmpty().MaximumLength(50);
            RuleFor(v => v.ReasonType).NotEmpty().MaximumLength(50);
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}