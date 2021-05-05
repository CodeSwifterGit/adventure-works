using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.CurrencyRate.Queries.GetCurrencyRateDetail
{
    public partial class GetCurrencyRateDetailQueryValidator : AbstractValidator<GetCurrencyRateDetailQuery>
    {
        public GetCurrencyRateDetailQueryValidator()
        {
            RuleFor(v => v.CurrencyRateID).NotEmpty();
        }
    }
}
