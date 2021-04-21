using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.BillOfMaterials.Queries.GetBillOfMaterials;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.BillOfMaterials.Commands.UpdateBillOfMaterials
{
    public partial class UpdateBillOfMaterialsSetCommand : IRequest<List<BillOfMaterialsLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateBillOfMaterialsCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseBillOfMaterials>, List<UpdateBillOfMaterialsCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateBillOfMaterialsCommand>, List<Entities.BillOfMaterials>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.BillOfMaterials>, List<Entities.BillOfMaterials>>(MemberList.None);
        }
    }
}