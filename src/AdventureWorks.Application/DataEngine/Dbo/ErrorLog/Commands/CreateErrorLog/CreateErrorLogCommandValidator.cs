using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Dbo.ErrorLog.Commands.CreateErrorLog
{
    public partial class CreateErrorLogCommandValidator : AbstractValidator<CreateErrorLogCommand>
    {
        public CreateErrorLogCommandValidator()
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