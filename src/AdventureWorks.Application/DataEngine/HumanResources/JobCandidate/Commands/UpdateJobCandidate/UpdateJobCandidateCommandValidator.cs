using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.HumanResources.JobCandidate.Commands.UpdateJobCandidate
{
    public partial class UpdateJobCandidateCommandValidator : AbstractValidator<UpdateJobCandidateCommand>
    {
        public UpdateJobCandidateCommandValidator()
        {
            RuleFor(v => v.JobCandidateID).NotEmpty();
            RuleFor(v => v.EmployeeID).NotEmpty();
            RuleFor(v => v.Resume).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}