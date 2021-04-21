using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Dbo.AWBuildVersion.Commands.CreateAWBuildVersion
{
    public partial class CreateAWBuildVersionCommandValidator : AbstractValidator<CreateAWBuildVersionCommand>
    {
        public CreateAWBuildVersionCommandValidator()
        {
            RuleFor(v => v.SystemInformationID).NotEmpty();
            RuleFor(v => v.DatabaseVersion).NotEmpty().MaximumLength(25);
            RuleFor(v => v.VersionDate).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}