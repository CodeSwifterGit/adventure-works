using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Purchasing.ShipMethod.Commands.CreateShipMethod
{
    public partial class CreateShipMethodCommandValidator : AbstractValidator<CreateShipMethodCommand>
    {
        public CreateShipMethodCommandValidator()
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