using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Dbo.ErrorLog.Commands.DeleteErrorLog
{
    public partial class DeleteErrorLogCommandValidator : AbstractValidator<DeleteErrorLogCommand>
    {
        public DeleteErrorLogCommandValidator()
        {

        }
    }
}
