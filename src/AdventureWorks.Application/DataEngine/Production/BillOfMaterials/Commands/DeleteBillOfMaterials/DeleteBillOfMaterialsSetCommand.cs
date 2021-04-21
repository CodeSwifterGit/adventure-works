using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Production.BillOfMaterials.Commands.DeleteBillOfMaterials
{
    public partial class DeleteBillOfMaterialsSetCommand : IRequest
    {
        public List<DeleteBillOfMaterialsCommand> Commands { get; set; }
    }
}