using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Application.DataEngine.Production.ProductListPriceHistory.Queries.GetProductListPriceHistories;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.ProductListPriceHistory.Commands.UpdateProductListPriceHistory
{
    public partial class UpdateProductListPriceHistoryCommand : BaseProductListPriceHistory, IRequest<ProductListPriceHistoryLookupModel>, IHaveCustomMapping
    {
        public int ProductID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal ListPrice { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateProductListPriceHistoryRequestTarget RequestTarget { get; set; }

        public UpdateProductListPriceHistoryCommand()
        {
        }

        public UpdateProductListPriceHistoryCommand(int productID, DateTime startDate, BaseProductListPriceHistory model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateProductListPriceHistoryRequestTarget(productID, startDate);
        }

        public UpdateProductListPriceHistoryCommand(int productID, DateTime startDate)
        {
            ProductID = productID;
            StartDate = startDate;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseProductListPriceHistory, UpdateProductListPriceHistoryCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateProductListPriceHistoryCommand, Entities.ProductListPriceHistory>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.ProductListPriceHistory, Entities.ProductListPriceHistory>(MemberList.None);
        }

        public partial class UpdateProductListPriceHistoryRequestTarget
        {
            public int ProductID { get; set; }
            public DateTime StartDate { get; set; }

            public UpdateProductListPriceHistoryRequestTarget()
            {
            }

            public UpdateProductListPriceHistoryRequestTarget(int productID, DateTime startDate)
            {
                ProductID = productID;
                StartDate = startDate;
            }
        }
    }
}