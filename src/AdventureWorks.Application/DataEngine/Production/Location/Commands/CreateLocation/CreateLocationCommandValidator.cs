using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.Location.Commands.CreateLocation
{
    public partial class CreateLocationCommandValidator : AbstractValidator<CreateLocationCommand>
    {
        public CreateLocationCommandValidator()
        {
            RuleFor(v => v.LocationID).NotEmpty();
            RuleFor(v => v.Name).NotEmpty().MaximumLength(50);
            RuleFor(v => v.CostRate).NotEmpty();
            RuleFor(v => v.Availability).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}