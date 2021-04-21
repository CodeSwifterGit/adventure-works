using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.Store.Commands.CreateStore
{
    public partial class CreateStoreCommandValidator : AbstractValidator<CreateStoreCommand>
    {
        public CreateStoreCommandValidator()
        {
            RuleFor(v => v.CustomerID).NotEmpty();
            RuleFor(v => v.Name).NotEmpty().MaximumLength(50);
            RuleFor(v => v.SalesPersonID).NotEmpty();
            RuleFor(v => v.Demographics).NotEmpty();
            RuleFor(v => v.Rowguid).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}