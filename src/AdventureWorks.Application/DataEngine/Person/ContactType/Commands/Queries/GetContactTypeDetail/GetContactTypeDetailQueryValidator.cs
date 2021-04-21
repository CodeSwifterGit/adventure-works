using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Person.ContactType.Queries.GetContactTypeDetail
{
    public partial class GetContactTypeDetailQueryValidator : AbstractValidator<GetContactTypeDetailQuery>
    {
        public GetContactTypeDetailQueryValidator()
        {
            RuleFor(v => v.ContactTypeID).NotEmpty();
        }
    }
}
