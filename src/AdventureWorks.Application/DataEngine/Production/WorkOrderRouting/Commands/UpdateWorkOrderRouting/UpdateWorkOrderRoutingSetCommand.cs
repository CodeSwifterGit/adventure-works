using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.WorkOrderRouting.Queries.GetWorkOrderRoutings;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.WorkOrderRouting.Commands.UpdateWorkOrderRouting
{
    public partial class UpdateWorkOrderRoutingSetCommand : IRequest<List<WorkOrderRoutingLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateWorkOrderRoutingCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseWorkOrderRouting>, List<UpdateWorkOrderRoutingCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateWorkOrderRoutingCommand>, List<Entities.WorkOrderRouting>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.WorkOrderRouting>, List<Entities.WorkOrderRouting>>(MemberList.None);
        }
    }
}