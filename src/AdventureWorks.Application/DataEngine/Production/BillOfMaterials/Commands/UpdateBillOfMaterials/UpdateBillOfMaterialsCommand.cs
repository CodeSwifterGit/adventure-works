using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Application.DataEngine.Production.BillOfMaterials.Queries.GetBillOfMaterials;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.BillOfMaterials.Commands.UpdateBillOfMaterials
{
    public partial class UpdateBillOfMaterialsCommand : BaseBillOfMaterials, IRequest<BillOfMaterialsLookupModel>, IHaveCustomMapping
    {
        public int BillOfMaterialsID { get; set; }
        public int? ProductAssemblyID { get; set; }
        public int ComponentID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string UnitMeasureCode { get; set; }
        public short BOMLevel { get; set; }
        public decimal PerAssemblyQty { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateBillOfMaterialsRequestTarget RequestTarget { get; set; }

        public UpdateBillOfMaterialsCommand()
        {
        }

        public UpdateBillOfMaterialsCommand(int billOfMaterialsID, BaseBillOfMaterials model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateBillOfMaterialsRequestTarget(billOfMaterialsID);
        }

        public UpdateBillOfMaterialsCommand(int billOfMaterialsID)
        {
            BillOfMaterialsID = billOfMaterialsID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseBillOfMaterials, UpdateBillOfMaterialsCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateBillOfMaterialsCommand, Entities.BillOfMaterials>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.BillOfMaterials, Entities.BillOfMaterials>(MemberList.None);
        }

        public partial class UpdateBillOfMaterialsRequestTarget
        {
            public int BillOfMaterialsID { get; set; }

            public UpdateBillOfMaterialsRequestTarget()
            {
            }

            public UpdateBillOfMaterialsRequestTarget(int billOfMaterialsID)
            {
                BillOfMaterialsID = billOfMaterialsID;
            }
        }
    }
}