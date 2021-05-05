using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.Currency.Queries.GetCurrencyDetail
{
    public partial class GetCurrencyDetailQueryValidator : AbstractValidator<GetCurrencyDetailQuery>
    {
        public GetCurrencyDetailQueryValidator()
        {
            RuleFor(v => v.CurrencyCode).NotEmpty().MaximumLength(3);
        }
    }
}
