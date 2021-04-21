using FluentValidation;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Commands.CreateEmployeeAddress
{
    public partial class CreateEmployeeAddressCommandValidator : AbstractValidator<CreateEmployeeAddressCommand>
    {
        public CreateEmployeeAddressCommandValidator()
        {
            RuleFor(v => v.EmployeeID).NotEmpty();
            RuleFor(v => v.AddressID).NotEmpty();
            RuleFor(v => v.Rowguid).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}