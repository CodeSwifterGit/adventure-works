using FluentValidation;

namespace AdventureWorks.Application.DataEngine.Production.BillOfMaterials.Commands.CreateBillOfMaterials
{
    public partial class CreateBillOfMaterialsCommandValidator : AbstractValidator<CreateBillOfMaterialsCommand>
    {
        public CreateBillOfMaterialsCommandValidator()
        {
            RuleFor(v => v.BillOfMaterialsID).NotEmpty();
            RuleFor(v => v.ProductAssemblyID).NotEmpty();
            RuleFor(v => v.ComponentID).NotEmpty();
            RuleFor(v => v.StartDate).NotEmpty();
            RuleFor(v => v.EndDate).NotEmpty();
            RuleFor(v => v.UnitMeasureCode).NotEmpty().MaximumLength(3);
            RuleFor(v => v.BOMLevel).NotEmpty();
            RuleFor(v => v.PerAssemblyQty).NotEmpty();
            RuleFor(v => v.ModifiedDate).NotEmpty();
        }
    }
}