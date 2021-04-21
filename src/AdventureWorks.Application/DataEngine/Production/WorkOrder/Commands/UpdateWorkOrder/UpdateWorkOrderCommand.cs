using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Application.DataEngine.Production.WorkOrder.Queries.GetWorkOrders;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.WorkOrder.Commands.UpdateWorkOrder
{
    public partial class UpdateWorkOrderCommand : BaseWorkOrder, IRequest<WorkOrderLookupModel>, IHaveCustomMapping
    {
        public int WorkOrderID { get; set; }
        public int ProductID { get; set; }
        public int OrderQty { get; set; }
        public int StockedQty { get; set; }
        public short ScrappedQty { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime DueDate { get; set; }
        public short? ScrapReasonID { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateWorkOrderRequestTarget RequestTarget { get; set; }

        public UpdateWorkOrderCommand()
        {
        }

        public UpdateWorkOrderCommand(int workOrderID, BaseWorkOrder model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateWorkOrderRequestTarget(workOrderID);
        }

        public UpdateWorkOrderCommand(int workOrderID)
        {
            WorkOrderID = workOrderID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseWorkOrder, UpdateWorkOrderCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateWorkOrderCommand, Entities.WorkOrder>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.WorkOrder, Entities.WorkOrder>(MemberList.None);
        }

        public partial class UpdateWorkOrderRequestTarget
        {
            public int WorkOrderID { get; set; }

            public UpdateWorkOrderRequestTarget()
            {
            }

            public UpdateWorkOrderRequestTarget(int workOrderID)
            {
                WorkOrderID = workOrderID;
            }
        }
    }
}