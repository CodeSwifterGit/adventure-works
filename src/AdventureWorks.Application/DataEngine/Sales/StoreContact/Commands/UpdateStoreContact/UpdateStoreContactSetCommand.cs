using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.StoreContact.Queries.GetStoreContacts;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.StoreContact.Commands.UpdateStoreContact
{
    public partial class UpdateStoreContactSetCommand : IRequest<List<StoreContactLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateStoreContactCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseStoreContact>, List<UpdateStoreContactCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateStoreContactCommand>, List<Entities.StoreContact>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.StoreContact>, List<Entities.StoreContact>>(MemberList.None);
        }
    }
}