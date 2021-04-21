using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.BillOfMaterials.Commands.DeleteBillOfMaterials
{
    public partial class DeleteBillOfMaterialsCommand : IRequest
    {
        public int BillOfMaterialsID { get; set; }
    }
}