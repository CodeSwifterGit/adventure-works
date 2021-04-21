using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.Location.Commands.UpdateLocation
{
    public partial class UpdateLocationCommandValidator : AbstractValidator<UpdateLocationCommand>
    {
        public UpdateLocationCommandValidator()
        {
            RuleFor(v => v.LocationID).NotEmpty();
            RuleFor(v => v.Name).NotEmpty().MaximumLength(50);
            RuleFor(v => v.CostRate).NotEmpty();
            RuleFor(v => v.Availability).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}