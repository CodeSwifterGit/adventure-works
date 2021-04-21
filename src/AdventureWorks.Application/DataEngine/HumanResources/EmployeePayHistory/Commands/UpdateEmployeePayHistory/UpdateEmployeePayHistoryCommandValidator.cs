using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Commands.UpdateEmployeePayHistory
{
    public partial class UpdateEmployeePayHistoryCommandValidator : AbstractValidator<UpdateEmployeePayHistoryCommand>
    {
        public UpdateEmployeePayHistoryCommandValidator()
        {
            RuleFor(v => v.EmployeeID).NotEmpty();
            RuleFor(v => v.RateChangeDate).NotEmpty();
            RuleFor(v => v.Rate).NotEmpty();
            RuleFor(v => v.PayFrequency).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}