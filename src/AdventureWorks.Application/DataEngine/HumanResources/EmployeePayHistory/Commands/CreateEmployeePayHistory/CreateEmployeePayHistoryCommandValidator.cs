using FluentValidation;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Commands.CreateEmployeePayHistory
{
    public partial class CreateEmployeePayHistoryCommandValidator : AbstractValidator<CreateEmployeePayHistoryCommand>
    {
        public CreateEmployeePayHistoryCommandValidator()
        {
            RuleFor(v => v.EmployeeID).NotEmpty();
            RuleFor(v => v.RateChangeDate).NotEmpty();
            RuleFor(v => v.Rate).NotEmpty();
            RuleFor(v => v.PayFrequency).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}