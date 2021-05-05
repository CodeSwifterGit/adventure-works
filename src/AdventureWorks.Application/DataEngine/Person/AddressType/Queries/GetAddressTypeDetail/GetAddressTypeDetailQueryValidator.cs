using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Person.AddressType.Queries.GetAddressTypeDetail
{
    public partial class GetAddressTypeDetailQueryValidator : AbstractValidator<GetAddressTypeDetailQuery>
    {
        public GetAddressTypeDetailQueryValidator()
        {
            RuleFor(v => v.AddressTypeID).NotEmpty();
        }
    }
}
