using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Purchasing.Vendor.Queries.GetVendorDetail
{
    public partial class GetVendorDetailQueryValidator : AbstractValidator<GetVendorDetailQuery>
    {
        public GetVendorDetailQueryValidator()
        {
            RuleFor(v => v.VendorID).NotEmpty();
        }
    }
}
