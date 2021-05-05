using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Application.DataEngine.Production.ProductInventory.Queries.GetProductInventories;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.ProductInventory.Commands.UpdateProductInventory
{
    public partial class UpdateProductInventoryCommand : IRequest<ProductInventoryLookupModel>, IHaveCustomMapping
    {
        public int ProductID { get; set; }
        public short LocationID { get; set; }
        public string Shelf { get; set; }
        public byte Bin { get; set; }
        public short Quantity { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateProductInventoryRequestTarget RequestTarget { get; set; }

        public UpdateProductInventoryCommand()
        {
        }

        public UpdateProductInventoryCommand(int productID, short locationID, BaseProductInventory model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateProductInventoryRequestTarget(productID, locationID);
        }

        public UpdateProductInventoryCommand(int productID, short locationID)
        {
            ProductID = productID;
            LocationID = locationID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseProductInventory, UpdateProductInventoryCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateProductInventoryCommand, Entities.ProductInventory>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.ProductInventory, Entities.ProductInventory>(MemberList.None);
        }

        public partial class UpdateProductInventoryRequestTarget
        {
            public int ProductID { get; set; }
            public short LocationID { get; set; }

            public UpdateProductInventoryRequestTarget()
            {
            }

            public UpdateProductInventoryRequestTarget(int productID, short locationID)
            {
                ProductID = productID;
                LocationID = locationID;
            }
        }
    }
}