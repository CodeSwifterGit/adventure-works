using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Production.BillOfMaterials.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Production.BillOfMaterials.Queries.GetBillOfMaterials;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.BillOfMaterials.Queries.GetBillOfMaterialsDetail
{
    public partial class GetBillOfMaterialsDetailQuery : IRequest<BillOfMaterialsLookupModel>
    {
        public int BillOfMaterialsID { get; set; }
    }
}
