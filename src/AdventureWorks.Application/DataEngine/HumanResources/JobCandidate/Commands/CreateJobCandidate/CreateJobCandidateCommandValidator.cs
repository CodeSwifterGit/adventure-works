using FluentValidation;

namespace AdventureWorks.Application.DataEngine.HumanResources.JobCandidate.Commands.CreateJobCandidate
{
    public partial class CreateJobCandidateCommandValidator : AbstractValidator<CreateJobCandidateCommand>
    {
        public CreateJobCandidateCommandValidator()
        {
            RuleFor(v => v.JobCandidateID).NotEmpty();
            RuleFor(v => v.EmployeeID).NotEmpty();
            RuleFor(v => v.Resume).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}