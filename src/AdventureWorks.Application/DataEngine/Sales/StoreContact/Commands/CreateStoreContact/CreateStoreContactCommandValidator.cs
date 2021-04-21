using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.StoreContact.Commands.CreateStoreContact
{
    public partial class CreateStoreContactCommandValidator : AbstractValidator<CreateStoreContactCommand>
    {
        public CreateStoreContactCommandValidator()
        {
            RuleFor(v => v.CustomerID).NotEmpty();
            RuleFor(v => v.ContactID).NotEmpty();
            RuleFor(v => v.ContactTypeID).NotEmpty();
            RuleFor(v => v.Rowguid).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}