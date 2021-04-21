using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Person.StateProvince.Commands.DeleteStateProvince
{
    public partial class DeleteStateProvinceCommandValidator : AbstractValidator<DeleteStateProvinceCommand>
    {
        public DeleteStateProvinceCommandValidator()
        {
            RuleFor(v => v.StateProvinceID).NotEmpty();
        }
    }
}
