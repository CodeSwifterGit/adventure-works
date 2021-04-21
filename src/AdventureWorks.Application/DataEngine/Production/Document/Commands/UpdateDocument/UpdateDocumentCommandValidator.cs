using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.Document.Commands.UpdateDocument
{
    public partial class UpdateDocumentCommandValidator : AbstractValidator<UpdateDocumentCommand>
    {
        public UpdateDocumentCommandValidator()
        {
            RuleFor(v => v.DocumentID).NotEmpty();
            RuleFor(v => v.Title).NotEmpty().MaximumLength(50);
            RuleFor(v => v.FileName).NotEmpty().MaximumLength(400);
            RuleFor(v => v.FileExtension).NotEmpty().MaximumLength(8);
            RuleFor(v => v.Revision).NotEmpty().MaximumLength(5);
            RuleFor(v => v.ChangeNumber).NotEmpty();
            RuleFor(v => v.Status).NotEmpty();
            RuleFor(v => v.DocumentSummary).NotEmpty().MaximumLength(-1);
            RuleFor(v => v.Document).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}