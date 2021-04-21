using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Application.DataEngine.Sales.SalesReason.Queries.GetSalesReasons;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.SalesReason.Commands.UpdateSalesReason
{
    public partial class UpdateSalesReasonCommand : BaseSalesReason, IRequest<SalesReasonLookupModel>, IHaveCustomMapping
    {
        public int SalesReasonID { get; set; }
        public string Name { get; set; }
        public string ReasonType { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateSalesReasonRequestTarget RequestTarget { get; set; }

        public UpdateSalesReasonCommand()
        {
        }

        public UpdateSalesReasonCommand(int salesReasonID, BaseSalesReason model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateSalesReasonRequestTarget(salesReasonID);
        }

        public UpdateSalesReasonCommand(int salesReasonID)
        {
            SalesReasonID = salesReasonID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseSalesReason, UpdateSalesReasonCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateSalesReasonCommand, Entities.SalesReason>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.SalesReason, Entities.SalesReason>(MemberList.None);
        }

        public partial class UpdateSalesReasonRequestTarget
        {
            public int SalesReasonID { get; set; }

            public UpdateSalesReasonRequestTarget()
            {
            }

            public UpdateSalesReasonRequestTarget(int salesReasonID)
            {
                SalesReasonID = salesReasonID;
            }
        }
    }
}