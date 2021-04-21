using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.StoreContact.Commands.UpdateStoreContact
{
    public partial class UpdateStoreContactCommandValidator : AbstractValidator<UpdateStoreContactCommand>
    {
        public UpdateStoreContactCommandValidator()
        {
            RuleFor(v => v.CustomerID).NotEmpty();
            RuleFor(v => v.ContactID).NotEmpty();
            RuleFor(v => v.ContactTypeID).NotEmpty();
            RuleFor(v => v.Rowguid).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}