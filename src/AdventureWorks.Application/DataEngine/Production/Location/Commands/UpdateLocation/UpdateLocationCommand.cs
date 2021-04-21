using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Application.DataEngine.Production.Location.Queries.GetLocations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.Location.Commands.UpdateLocation
{
    public partial class UpdateLocationCommand : BaseLocation, IRequest<LocationLookupModel>, IHaveCustomMapping
    {
        public short LocationID { get; set; }
        public string Name { get; set; }
        public decimal CostRate { get; set; }
        public decimal Availability { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateLocationRequestTarget RequestTarget { get; set; }

        public UpdateLocationCommand()
        {
        }

        public UpdateLocationCommand(short locationID, BaseLocation model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateLocationRequestTarget(locationID);
        }

        public UpdateLocationCommand(short locationID)
        {
            LocationID = locationID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseLocation, UpdateLocationCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateLocationCommand, Entities.Location>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.Location, Entities.Location>(MemberList.None);
        }

        public partial class UpdateLocationRequestTarget
        {
            public short LocationID { get; set; }

            public UpdateLocationRequestTarget()
            {
            }

            public UpdateLocationRequestTarget(short locationID)
            {
                LocationID = locationID;
            }
        }
    }
}