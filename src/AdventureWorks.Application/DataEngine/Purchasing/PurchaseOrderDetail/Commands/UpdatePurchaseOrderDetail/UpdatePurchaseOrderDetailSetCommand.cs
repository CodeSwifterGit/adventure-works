using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderDetail.Queries.GetPurchaseOrderDetails;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Purchasing;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Purchasing;


namespace AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderDetail.Commands.UpdatePurchaseOrderDetail
{
    public partial class UpdatePurchaseOrderDetailSetCommand : IRequest<List<PurchaseOrderDetailLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdatePurchaseOrderDetailCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BasePurchaseOrderDetail>, List<UpdatePurchaseOrderDetailCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdatePurchaseOrderDetailCommand>, List<Entities.PurchaseOrderDetail>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.PurchaseOrderDetail>, List<Entities.PurchaseOrderDetail>>(MemberList.None);
        }
    }
}