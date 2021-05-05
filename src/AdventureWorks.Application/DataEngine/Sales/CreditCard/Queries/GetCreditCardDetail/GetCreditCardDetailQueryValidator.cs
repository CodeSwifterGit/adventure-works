using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.CreditCard.Queries.GetCreditCardDetail
{
    public partial class GetCreditCardDetailQueryValidator : AbstractValidator<GetCreditCardDetailQuery>
    {
        public GetCreditCardDetailQueryValidator()
        {
            RuleFor(v => v.CreditCardID).NotEmpty();
        }
    }
}
