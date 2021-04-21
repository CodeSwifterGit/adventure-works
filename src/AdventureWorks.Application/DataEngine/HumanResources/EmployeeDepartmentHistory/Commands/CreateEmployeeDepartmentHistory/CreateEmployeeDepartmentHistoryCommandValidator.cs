using FluentValidation;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Commands.CreateEmployeeDepartmentHistory
{
    public partial class CreateEmployeeDepartmentHistoryCommandValidator : AbstractValidator<CreateEmployeeDepartmentHistoryCommand>
    {
        public CreateEmployeeDepartmentHistoryCommandValidator()
        {
            RuleFor(v => v.EmployeeID).NotEmpty();
            RuleFor(v => v.DepartmentID).NotEmpty();
            RuleFor(v => v.ShiftID).NotEmpty();
            RuleFor(v => v.StartDate).NotEmpty();
            RuleFor(v => v.EndDate).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}