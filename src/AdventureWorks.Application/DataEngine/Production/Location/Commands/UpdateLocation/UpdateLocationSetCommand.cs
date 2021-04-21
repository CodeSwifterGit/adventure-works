using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.Location.Queries.GetLocations;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.Location.Commands.UpdateLocation
{
    public partial class UpdateLocationSetCommand : IRequest<List<LocationLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateLocationCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseLocation>, List<UpdateLocationCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateLocationCommand>, List<Entities.Location>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.Location>, List<Entities.Location>>(MemberList.None);
        }
    }
}