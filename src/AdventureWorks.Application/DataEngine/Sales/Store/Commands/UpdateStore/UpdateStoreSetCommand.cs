using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.Store.Queries.GetStores;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.Store.Commands.UpdateStore
{
    public partial class UpdateStoreSetCommand : IRequest<List<StoreLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateStoreCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseStore>, List<UpdateStoreCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateStoreCommand>, List<Entities.Store>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.Store>, List<Entities.Store>>(MemberList.None);
        }
    }
}