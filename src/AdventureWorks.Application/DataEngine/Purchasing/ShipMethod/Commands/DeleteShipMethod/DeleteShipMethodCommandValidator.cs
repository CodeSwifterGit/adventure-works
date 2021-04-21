using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Purchasing.ShipMethod.Commands.DeleteShipMethod
{
    public partial class DeleteShipMethodCommandValidator : AbstractValidator<DeleteShipMethodCommand>
    {
        public DeleteShipMethodCommandValidator()
        {
            RuleFor(v => v.ShipMethodID).NotEmpty();
        }
    }
}
