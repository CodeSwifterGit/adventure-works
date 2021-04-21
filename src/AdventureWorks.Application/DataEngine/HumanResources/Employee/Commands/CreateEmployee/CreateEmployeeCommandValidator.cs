using FluentValidation;

namespace AdventureWorks.Application.DataEngine.HumanResources.Employee.Commands.CreateEmployee
{
    public partial class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(v => v.EmployeeID).NotEmpty();
            RuleFor(v => v.NationalIDNumber).NotEmpty().MaximumLength(15);
            RuleFor(v => v.ContactID).NotEmpty();
            RuleFor(v => v.LoginID).NotEmpty().MaximumLength(256);
            RuleFor(v => v.ManagerID).NotEmpty();
            RuleFor(v => v.Title).NotEmpty().MaximumLength(50);
            RuleFor(v => v.BirthDate).NotEmpty();
            RuleFor(v => v.MaritalStatus).NotEmpty().MaximumLength(1);
            RuleFor(v => v.Gender).NotEmpty().MaximumLength(1);
            RuleFor(v => v.HireDate).NotEmpty();
            RuleFor(v => v.SalariedFlag).NotEmpty();
            RuleFor(v => v.VacationHours).NotEmpty();
            RuleFor(v => v.SickLeaveHours).NotEmpty();
            RuleFor(v => v.CurrentFlag).NotEmpty();
            RuleFor(v => v.Rowguid).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}