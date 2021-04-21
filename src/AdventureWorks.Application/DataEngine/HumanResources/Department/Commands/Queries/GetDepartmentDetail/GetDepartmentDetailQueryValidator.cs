using FluentValidation;

namespace AdventureWorks.Application.DataEngine.HumanResources.Department.Queries.GetDepartmentDetail
{
    public partial class GetDepartmentDetailQueryValidator : AbstractValidator<GetDepartmentDetailQuery>
    {
        public GetDepartmentDetailQueryValidator()
        {
            RuleFor(v => v.DepartmentID).NotEmpty();
        }
    }
}
