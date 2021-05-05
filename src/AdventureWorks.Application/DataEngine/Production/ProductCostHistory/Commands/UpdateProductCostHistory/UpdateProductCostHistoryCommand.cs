using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Application.DataEngine.Production.ProductCostHistory.Queries.GetProductCostHistories;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.ProductCostHistory.Commands.UpdateProductCostHistory
{
    public partial class UpdateProductCostHistoryCommand : IRequest<ProductCostHistoryLookupModel>, IHaveCustomMapping
    {
        public int ProductID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal StandardCost { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateProductCostHistoryRequestTarget RequestTarget { get; set; }

        public UpdateProductCostHistoryCommand()
        {
        }

        public UpdateProductCostHistoryCommand(int productID, DateTime startDate, BaseProductCostHistory model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateProductCostHistoryRequestTarget(productID, startDate);
        }

        public UpdateProductCostHistoryCommand(int productID, DateTime startDate)
        {
            ProductID = productID;
            StartDate = startDate;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseProductCostHistory, UpdateProductCostHistoryCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateProductCostHistoryCommand, Entities.ProductCostHistory>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.ProductCostHistory, Entities.ProductCostHistory>(MemberList.None);
        }

        public partial class UpdateProductCostHistoryRequestTarget
        {
            public int ProductID { get; set; }
            public DateTime StartDate { get; set; }

            public UpdateProductCostHistoryRequestTarget()
            {
            }

            public UpdateProductCostHistoryRequestTarget(int productID, DateTime startDate)
            {
                ProductID = productID;
                StartDate = startDate;
            }
        }
    }
}