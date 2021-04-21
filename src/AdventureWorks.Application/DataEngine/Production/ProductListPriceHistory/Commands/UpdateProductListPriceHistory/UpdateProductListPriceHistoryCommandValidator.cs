using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductListPriceHistory.Commands.UpdateProductListPriceHistory
{
    public partial class UpdateProductListPriceHistoryCommandValidator : AbstractValidator<UpdateProductListPriceHistoryCommand>
    {
        public UpdateProductListPriceHistoryCommandValidator()
        {
            RuleFor(v => v.ProductID).NotEmpty();
            RuleFor(v => v.StartDate).NotEmpty();
            RuleFor(v => v.EndDate).NotEmpty();
            RuleFor(v => v.ListPrice).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}