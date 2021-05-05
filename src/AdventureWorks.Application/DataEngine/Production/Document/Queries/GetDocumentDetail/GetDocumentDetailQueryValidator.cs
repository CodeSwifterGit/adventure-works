using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.Document.Queries.GetDocumentDetail
{
    public partial class GetDocumentDetailQueryValidator : AbstractValidator<GetDocumentDetailQuery>
    {
        public GetDocumentDetailQueryValidator()
        {
            RuleFor(v => v.DocumentID).NotEmpty();
        }
    }
}
