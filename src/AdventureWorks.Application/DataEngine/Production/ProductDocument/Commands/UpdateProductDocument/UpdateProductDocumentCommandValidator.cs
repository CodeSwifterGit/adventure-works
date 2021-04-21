using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductDocument.Commands.UpdateProductDocument
{
    public partial class UpdateProductDocumentCommandValidator : AbstractValidator<UpdateProductDocumentCommand>
    {
        public UpdateProductDocumentCommandValidator()
        {
            RuleFor(v => v.ProductID).NotEmpty();
            RuleFor(v => v.DocumentID).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}