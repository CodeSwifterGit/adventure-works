using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Person.StateProvince.Commands.UpdateStateProvince
{
    public partial class UpdateStateProvinceCommandValidator : AbstractValidator<UpdateStateProvinceCommand>
    {
        public UpdateStateProvinceCommandValidator()
        {
            RuleFor(v => v.StateProvinceID).NotEmpty();
            RuleFor(v => v.StateProvinceCode).NotEmpty().MaximumLength(3);
            RuleFor(v => v.CountryRegionCode).NotEmpty().MaximumLength(3);
            RuleFor(v => v.IsOnlyStateProvinceFlag).NotEmpty();
            RuleFor(v => v.Name).NotEmpty().MaximumLength(50);
            RuleFor(v => v.TerritoryID).NotEmpty();
            RuleFor(v => v.Rowguid).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}