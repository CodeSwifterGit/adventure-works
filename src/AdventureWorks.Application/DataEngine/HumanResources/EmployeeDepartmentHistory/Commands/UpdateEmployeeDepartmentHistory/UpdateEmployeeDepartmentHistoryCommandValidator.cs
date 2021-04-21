using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Commands.UpdateEmployeeDepartmentHistory
{
    public partial class UpdateEmployeeDepartmentHistoryCommandValidator : AbstractValidator<UpdateEmployeeDepartmentHistoryCommand>
    {
        public UpdateEmployeeDepartmentHistoryCommandValidator()
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