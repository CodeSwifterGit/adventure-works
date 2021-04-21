using FluentValidation;

namespace AdventureWorks.Application.DataEngine.HumanResources.Employee.Queries.GetEmployeeDetail
{
    public partial class GetEmployeeDetailQueryValidator : AbstractValidator<GetEmployeeDetailQuery>
    {
        public GetEmployeeDetailQueryValidator()
        {
            RuleFor(v => v.EmployeeID).NotEmpty();
        }
    }
}
