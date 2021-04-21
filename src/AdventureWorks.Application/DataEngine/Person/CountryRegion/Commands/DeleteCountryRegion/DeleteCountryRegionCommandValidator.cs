using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Person.CountryRegion.Commands.DeleteCountryRegion
{
    public partial class DeleteCountryRegionCommandValidator : AbstractValidator<DeleteCountryRegionCommand>
    {
        public DeleteCountryRegionCommandValidator()
        {
            RuleFor(v => v.CountryRegionCode).NotEmpty().MaximumLength(3);
        }
    }
}
