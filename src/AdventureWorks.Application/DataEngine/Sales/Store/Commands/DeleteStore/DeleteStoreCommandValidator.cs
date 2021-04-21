using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.Store.Commands.DeleteStore
{
    public partial class DeleteStoreCommandValidator : AbstractValidator<DeleteStoreCommand>
    {
        public DeleteStoreCommandValidator()
        {
            RuleFor(v => v.CustomerID).NotEmpty();
        }
    }
}
