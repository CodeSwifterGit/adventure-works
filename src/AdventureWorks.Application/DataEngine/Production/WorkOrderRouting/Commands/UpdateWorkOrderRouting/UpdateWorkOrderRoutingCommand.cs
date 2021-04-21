using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Application.DataEngine.Production.WorkOrderRouting.Queries.GetWorkOrderRoutings;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.WorkOrderRouting.Commands.UpdateWorkOrderRouting
{
    public partial class UpdateWorkOrderRoutingCommand : BaseWorkOrderRouting, IRequest<WorkOrderRoutingLookupModel>, IHaveCustomMapping
    {
        public int WorkOrderID { get; set; }
        public int ProductID { get; set; }
        public short OperationSequence { get; set; }
        public short LocationID { get; set; }
        public DateTime ScheduledStartDate { get; set; }
        public DateTime ScheduledEndDate { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public decimal? ActualResourceHrs { get; set; }
        public decimal PlannedCost { get; set; }
        public decimal? ActualCost { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateWorkOrderRoutingRequestTarget RequestTarget { get; set; }

        public UpdateWorkOrderRoutingCommand()
        {
        }

        public UpdateWorkOrderRoutingCommand(int workOrderID, int productID, short operationSequence, BaseWorkOrderRouting model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateWorkOrderRoutingRequestTarget(workOrderID, productID, operationSequence);
        }

        public UpdateWorkOrderRoutingCommand(int workOrderID, int productID, short operationSequence)
        {
            WorkOrderID = workOrderID;
            ProductID = productID;
            OperationSequence = operationSequence;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseWorkOrderRouting, UpdateWorkOrderRoutingCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateWorkOrderRoutingCommand, Entities.WorkOrderRouting>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.WorkOrderRouting, Entities.WorkOrderRouting>(MemberList.None);
        }

        public partial class UpdateWorkOrderRoutingRequestTarget
        {
            public int WorkOrderID { get; set; }
            public int ProductID { get; set; }
            public short OperationSequence { get; set; }

            public UpdateWorkOrderRoutingRequestTarget()
            {
            }

            public UpdateWorkOrderRoutingRequestTarget(int workOrderID, int productID, short operationSequence)
            {
                WorkOrderID = workOrderID;
                ProductID = productID;
                OperationSequence = operationSequence;
            }
        }
    }
}