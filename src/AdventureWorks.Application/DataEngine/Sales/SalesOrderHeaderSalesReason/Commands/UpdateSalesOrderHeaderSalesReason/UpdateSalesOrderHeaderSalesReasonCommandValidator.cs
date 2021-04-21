using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Commands.UpdateSalesOrderHeaderSalesReason
{
    public partial class UpdateSalesOrderHeaderSalesReasonCommandValidator : AbstractValidator<UpdateSalesOrderHeaderSalesReasonCommand>
    {
        public UpdateSalesOrderHeaderSalesReasonCommandValidator()
        {
            RuleFor(v => v.SalesOrderID).NotEmpty();
            RuleFor(v => v.SalesReasonID).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}