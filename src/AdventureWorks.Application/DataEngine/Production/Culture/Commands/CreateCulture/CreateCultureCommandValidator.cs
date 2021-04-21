using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.Culture.Commands.CreateCulture
{
    public partial class CreateCultureCommandValidator : AbstractValidator<CreateCultureCommand>
    {
        public CreateCultureCommandValidator()
        {
            RuleFor(v => v.CultureID).NotEmpty().MaximumLength(6);
            RuleFor(v => v.Name).NotEmpty().MaximumLength(50);
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}