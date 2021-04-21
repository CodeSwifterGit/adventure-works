using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Dbo.ErrorLog.Commands.UpdateErrorLog
{
    public partial class UpdateErrorLogCommandValidator : AbstractValidator<UpdateErrorLogCommand>
    {
        public UpdateErrorLogCommandValidator()
        {
            RuleFor(v => v.ErrorLogID).NotEmpty();
            RuleFor(v => v.ErrorTime).NotEmpty();
            RuleFor(v => v.UserName).NotEmpty().MaximumLength(128);
            RuleFor(v => v.ErrorNumber).NotEmpty();
            RuleFor(v => v.ErrorSeverity).NotEmpty();
            RuleFor(v => v.ErrorState).NotEmpty();
            RuleFor(v => v.ErrorProcedure).NotEmpty().MaximumLength(126);
            RuleFor(v => v.ErrorLine).NotEmpty();
            RuleFor(v => v.ErrorMessage).NotEmpty().MaximumLength(4000);
        }
    }
}