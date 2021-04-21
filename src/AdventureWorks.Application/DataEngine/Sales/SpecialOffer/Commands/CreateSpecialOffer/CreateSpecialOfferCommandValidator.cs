using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.SpecialOffer.Commands.CreateSpecialOffer
{
    public partial class CreateSpecialOfferCommandValidator : AbstractValidator<CreateSpecialOfferCommand>
    {
        public CreateSpecialOfferCommandValidator()
        {
            RuleFor(v => v.SpecialOfferID).NotEmpty();
            RuleFor(v => v.Description).NotEmpty().MaximumLength(255);
            RuleFor(v => v.DiscountPct).NotEmpty();
            RuleFor(v => v.Type).NotEmpty().MaximumLength(50);
            RuleFor(v => v.Category).NotEmpty().MaximumLength(50);
            RuleFor(v => v.StartDate).NotEmpty();
            RuleFor(v => v.EndDate).NotEmpty();
            RuleFor(v => v.MinQty).NotEmpty();
            RuleFor(v => v.MaxQty).NotEmpty();
            RuleFor(v => v.Rowguid).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}