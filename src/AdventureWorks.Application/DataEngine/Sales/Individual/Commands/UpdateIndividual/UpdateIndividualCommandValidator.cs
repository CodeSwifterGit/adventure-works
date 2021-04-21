using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.Individual.Commands.UpdateIndividual
{
    public partial class UpdateIndividualCommandValidator : AbstractValidator<UpdateIndividualCommand>
    {
        public UpdateIndividualCommandValidator()
        {
            RuleFor(v => v.CustomerID).NotEmpty();
            RuleFor(v => v.ContactID).NotEmpty();
            RuleFor(v => v.Demographics).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}