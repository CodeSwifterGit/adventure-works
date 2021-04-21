using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductListPriceHistory.Queries.GetProductListPriceHistories;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.ProductListPriceHistory.Commands.UpdateProductListPriceHistory
{
    public partial class UpdateProductListPriceHistorySetCommand : IRequest<List<ProductListPriceHistoryLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateProductListPriceHistoryCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseProductListPriceHistory>, List<UpdateProductListPriceHistoryCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateProductListPriceHistoryCommand>, List<Entities.ProductListPriceHistory>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.ProductListPriceHistory>, List<Entities.ProductListPriceHistory>>(MemberList.None);
        }
    }
}