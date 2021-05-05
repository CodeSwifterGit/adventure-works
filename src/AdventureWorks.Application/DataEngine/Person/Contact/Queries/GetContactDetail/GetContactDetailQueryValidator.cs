using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Person.Contact.Queries.GetContactDetail
{
    public partial class GetContactDetailQueryValidator : AbstractValidator<GetContactDetailQuery>
    {
        public GetContactDetailQueryValidator()
        {
            RuleFor(v => v.ContactID).NotEmpty();
        }
    }
}
