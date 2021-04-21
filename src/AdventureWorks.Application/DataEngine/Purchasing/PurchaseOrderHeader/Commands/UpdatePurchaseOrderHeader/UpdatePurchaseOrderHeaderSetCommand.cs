using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderHeader.Queries.GetPurchaseOrderHeaders;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Purchasing;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Purchasing;


namespace AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderHeader.Commands.UpdatePurchaseOrderHeader
{
    public partial class UpdatePurchaseOrderHeaderSetCommand : IRequest<List<PurchaseOrderHeaderLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdatePurchaseOrderHeaderCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BasePurchaseOrderHeader>, List<UpdatePurchaseOrderHeaderCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdatePurchaseOrderHeaderCommand>, List<Entities.PurchaseOrderHeader>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.PurchaseOrderHeader>, List<Entities.PurchaseOrderHeader>>(MemberList.None);
        }
    }
}