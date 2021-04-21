using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Purchasing.ShipMethod.Commands.UpdateShipMethod
{
    public partial class UpdateShipMethodCommandValidator : AbstractValidator<UpdateShipMethodCommand>
    {
        public UpdateShipMethodCommandValidator()
        {
            RuleFor(v => v.ShipMethodID).NotEmpty();
            RuleFor(v => v.Name).NotEmpty().MaximumLength(50);
            RuleFor(v => v.ShipBase).NotEmpty();
            RuleFor(v => v.ShipRate).NotEmpty();
            RuleFor(v => v.Rowguid).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}