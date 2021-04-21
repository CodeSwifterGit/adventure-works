using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductCostHistory.Queries.GetProductCostHistories;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.ProductCostHistory.Commands.UpdateProductCostHistory
{
    public partial class UpdateProductCostHistorySetCommand : IRequest<List<ProductCostHistoryLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateProductCostHistoryCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseProductCostHistory>, List<UpdateProductCostHistoryCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateProductCostHistoryCommand>, List<Entities.ProductCostHistory>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.ProductCostHistory>, List<Entities.ProductCostHistory>>(MemberList.None);
        }
    }
}