using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Purchasing;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Purchasing;
using AdventureWorks.Application.DataEngine.Purchasing.ShipMethod.Queries.GetShipMethods;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Purchasing.ShipMethod.Commands.UpdateShipMethod
{
    public partial class UpdateShipMethodCommand : BaseShipMethod, IRequest<ShipMethodLookupModel>, IHaveCustomMapping
    {
        public int ShipMethodID { get; set; }
        public string Name { get; set; }
        public decimal ShipBase { get; set; }
        public decimal ShipRate { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateShipMethodRequestTarget RequestTarget { get; set; }

        public UpdateShipMethodCommand()
        {
        }

        public UpdateShipMethodCommand(int shipMethodID, BaseShipMethod model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateShipMethodRequestTarget(shipMethodID);
        }

        public UpdateShipMethodCommand(int shipMethodID)
        {
            ShipMethodID = shipMethodID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseShipMethod, UpdateShipMethodCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateShipMethodCommand, Entities.ShipMethod>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.ShipMethod, Entities.ShipMethod>(MemberList.None);
        }

        public partial class UpdateShipMethodRequestTarget
        {
            public int ShipMethodID { get; set; }

            public UpdateShipMethodRequestTarget()
            {
            }

            public UpdateShipMethodRequestTarget(int shipMethodID)
            {
                ShipMethodID = shipMethodID;
            }
        }
    }
}