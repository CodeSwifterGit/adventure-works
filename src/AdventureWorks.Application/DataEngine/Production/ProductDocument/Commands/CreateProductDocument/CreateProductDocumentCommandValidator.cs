using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.ProductDocument.Commands.CreateProductDocument
{
    public partial class CreateProductDocumentCommandValidator : AbstractValidator<CreateProductDocumentCommand>
    {
        public CreateProductDocumentCommandValidator()
        {
            RuleFor(v => v.ProductID).NotEmpty();
            RuleFor(v => v.DocumentID).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}