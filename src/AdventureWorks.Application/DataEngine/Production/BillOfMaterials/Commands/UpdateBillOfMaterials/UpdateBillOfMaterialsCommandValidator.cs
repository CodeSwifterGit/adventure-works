using FluentValidation;
using FluentValidation.Validators;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.BillOfMaterials.Commands.UpdateBillOfMaterials
{
    public partial class UpdateBillOfMaterialsCommandValidator : AbstractValidator<UpdateBillOfMaterialsCommand>
    {
        public UpdateBillOfMaterialsCommandValidator()
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