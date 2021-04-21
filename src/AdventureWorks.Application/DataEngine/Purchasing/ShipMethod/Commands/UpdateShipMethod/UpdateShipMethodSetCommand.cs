using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Purchasing.ShipMethod.Queries.GetShipMethods;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Purchasing;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Purchasing;


namespace AdventureWorks.Application.DataEngine.Purchasing.ShipMethod.Commands.UpdateShipMethod
{
    public partial class UpdateShipMethodSetCommand : IRequest<List<ShipMethodLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateShipMethodCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseShipMethod>, List<UpdateShipMethodCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateShipMethodCommand>, List<Entities.ShipMethod>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.ShipMethod>, List<Entities.ShipMethod>>(MemberList.None);
        }
    }
}