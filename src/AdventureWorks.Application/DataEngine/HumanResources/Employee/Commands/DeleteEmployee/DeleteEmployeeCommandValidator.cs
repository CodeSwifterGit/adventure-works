using FluentValidation;

namespace AdventureWorks.Application.DataEngine.HumanResources.Employee.Commands.DeleteEmployee
{
    public partial class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
    {
        public DeleteEmployeeCommandValidator()
        {
            RuleFor(v => v.EmployeeID).NotEmpty();
        }
    }
}
