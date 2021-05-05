using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.Store.Queries.GetStoreDetail
{
    public partial class GetStoreDetailQueryValidator : AbstractValidator<GetStoreDetailQuery>
    {
        public GetStoreDetailQueryValidator()
        {
            RuleFor(v => v.CustomerID).NotEmpty();
        }
    }
}
