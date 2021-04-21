using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Commands.UpdateProductModelIllustration
{
    public partial class UpdateProductModelIllustrationCommandValidator : AbstractValidator<UpdateProductModelIllustrationCommand>
    {
        public UpdateProductModelIllustrationCommandValidator()
        {
            RuleFor(v => v.ProductModelID).NotEmpty();
            RuleFor(v => v.IllustrationID).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}