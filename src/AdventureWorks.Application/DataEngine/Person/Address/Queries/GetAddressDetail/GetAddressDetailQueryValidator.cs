using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Person.Address.Queries.GetAddressDetail
{
    public partial class GetAddressDetailQueryValidator : AbstractValidator<GetAddressDetailQuery>
    {
        public GetAddressDetailQueryValidator()
        {
            RuleFor(v => v.AddressID).NotEmpty();
        }
    }
}
