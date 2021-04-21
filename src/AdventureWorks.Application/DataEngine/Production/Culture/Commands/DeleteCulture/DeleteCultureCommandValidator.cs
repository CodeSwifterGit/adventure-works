using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.Culture.Commands.DeleteCulture
{
    public partial class DeleteCultureCommandValidator : AbstractValidator<DeleteCultureCommand>
    {
        public DeleteCultureCommandValidator()
        {
            RuleFor(v => v.CultureID).NotEmpty().MaximumLength(6);
        }
    }
}
