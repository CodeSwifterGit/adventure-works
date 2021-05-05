using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Purchasing.ShipMethod.Queries.GetShipMethodDetail
{
    public partial class GetShipMethodDetailQueryValidator : AbstractValidator<GetShipMethodDetailQuery>
    {
        public GetShipMethodDetailQueryValidator()
        {
            RuleFor(v => v.ShipMethodID).NotEmpty();
        }
    }
}
