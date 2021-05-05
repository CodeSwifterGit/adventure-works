using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Application.DataEngine.Sales.Store.Queries.GetStores;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.Store.Commands.UpdateStore
{
    public partial class UpdateStoreCommand : IRequest<StoreLookupModel>, IHaveCustomMapping
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public int? SalesPersonID { get; set; }
        public string Demographics { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateStoreRequestTarget RequestTarget { get; set; }

        public UpdateStoreCommand()
        {
        }

        public UpdateStoreCommand(int customerID, BaseStore model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateStoreRequestTarget(customerID);
        }

        public UpdateStoreCommand(int customerID)
        {
            CustomerID = customerID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseStore, UpdateStoreCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateStoreCommand, Entities.Store>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.Store, Entities.Store>(MemberList.None);
        }

        public partial class UpdateStoreRequestTarget
        {
            public int CustomerID { get; set; }

            public UpdateStoreRequestTarget()
            {
            }

            public UpdateStoreRequestTarget(int customerID)
            {
                CustomerID = customerID;
            }
        }
    }
}