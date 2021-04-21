using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Person.CountryRegion.Commands.CreateCountryRegion
{
    public partial class CreateCountryRegionCommandValidator : AbstractValidator<CreateCountryRegionCommand>
    {
        public CreateCountryRegionCommandValidator()
        {
            RuleFor(v => v.CountryRegionCode).NotEmpty().MaximumLength(3);
            RuleFor(v => v.Name).NotEmpty().MaximumLength(50);
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}