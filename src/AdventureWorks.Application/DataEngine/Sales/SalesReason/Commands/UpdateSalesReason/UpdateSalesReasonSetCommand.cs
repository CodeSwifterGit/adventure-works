using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SalesReason.Queries.GetSalesReasons;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.SalesReason.Commands.UpdateSalesReason
{
    public partial class UpdateSalesReasonSetCommand : IRequest<List<SalesReasonLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateSalesReasonCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseSalesReason>, List<UpdateSalesReasonCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateSalesReasonCommand>, List<Entities.SalesReason>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.SalesReason>, List<Entities.SalesReason>>(MemberList.None);
        }
    }
}