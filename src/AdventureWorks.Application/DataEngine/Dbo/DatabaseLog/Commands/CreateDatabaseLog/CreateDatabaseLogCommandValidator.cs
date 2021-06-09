using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Dbo.DatabaseLog.Commands.CreateDatabaseLog
{
    public partial class CreateDatabaseLogCommandValidator : AbstractValidator<CreateDatabaseLogCommand>
    {
        public CreateDatabaseLogCommandValidator()
        {
            RuleFor(v => v.DatabaseLogID).NotEmpty();
            RuleFor(v => v.PostTime).NotEmpty();
            RuleFor(v => v.DatabaseUser).NotEmpty().MaximumLength(128);
            RuleFor(v => v.Event).NotEmpty().MaximumLength(128);
            RuleFor(v => v.Schema).NotEmpty().MaximumLength(128);
            RuleFor(v => v.Object).NotEmpty().MaximumLength(128);
            RuleFor(v => v.Tsql).NotEmpty();
            RuleFor(v => v.XmlEvent).NotEmpty();
        }
    }
}