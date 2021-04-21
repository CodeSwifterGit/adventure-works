using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Dbo.AWBuildVersion.Commands.UpdateAWBuildVersion
{
    public partial class UpdateAWBuildVersionCommandValidator : AbstractValidator<UpdateAWBuildVersionCommand>
    {
        public UpdateAWBuildVersionCommandValidator()
        {
            RuleFor(v => v.SystemInformationID).NotEmpty();
            RuleFor(v => v.DatabaseVersion).NotEmpty().MaximumLength(25);
            RuleFor(v => v.VersionDate).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}