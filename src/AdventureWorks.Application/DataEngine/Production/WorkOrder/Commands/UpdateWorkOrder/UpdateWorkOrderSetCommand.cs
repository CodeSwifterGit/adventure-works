using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.WorkOrder.Queries.GetWorkOrders;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.WorkOrder.Commands.UpdateWorkOrder
{
    public partial class UpdateWorkOrderSetCommand : IRequest<List<WorkOrderLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateWorkOrderCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseWorkOrder>, List<UpdateWorkOrderCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateWorkOrderCommand>, List<Entities.WorkOrder>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.WorkOrder>, List<Entities.WorkOrder>>(MemberList.None);
        }
    }
}