using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Dbo.DatabaseLog.Commands.UpdateDatabaseLog
{
    public partial class UpdateDatabaseLogCommandValidator : AbstractValidator<UpdateDatabaseLogCommand>
    {
        public UpdateDatabaseLogCommandValidator()
        {
            RuleFor(v => v.DatabaseLogID).NotEmpty();
            RuleFor(v => v.PostTime).NotEmpty();
            RuleFor(v => v.DatabaseUser).NotEmpty().MaximumLength(128);
            RuleFor(v => v.Event).NotEmpty().MaximumLength(128);
            RuleFor(v => v.Schema).NotEmpty().MaximumLength(128);
            RuleFor(v => v.Object).NotEmpty().MaximumLength(128);
            RuleFor(v => v.Tsql).NotEmpty().MaximumLength(-1);
            RuleFor(v => v.XmlEvent).NotEmpty();
        }
    }
}