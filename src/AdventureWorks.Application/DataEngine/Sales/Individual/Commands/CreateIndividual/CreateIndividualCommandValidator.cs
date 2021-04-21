using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Sales.Individual.Commands.CreateIndividual
{
    public partial class CreateIndividualCommandValidator : AbstractValidator<CreateIndividualCommand>
    {
        public CreateIndividualCommandValidator()
        {
            RuleFor(v => v.CustomerID).NotEmpty();
            RuleFor(v => v.ContactID).NotEmpty();
            RuleFor(v => v.Demographics).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}