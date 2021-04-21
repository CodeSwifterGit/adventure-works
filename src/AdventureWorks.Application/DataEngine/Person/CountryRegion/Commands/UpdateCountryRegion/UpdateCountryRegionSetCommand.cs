using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Person.CountryRegion.Queries.GetCountryRegions;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Person;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Person;


namespace AdventureWorks.Application.DataEngine.Person.CountryRegion.Commands.UpdateCountryRegion
{
    public partial class UpdateCountryRegionSetCommand : IRequest<List<CountryRegionLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateCountryRegionCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseCountryRegion>, List<UpdateCountryRegionCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateCountryRegionCommand>, List<Entities.CountryRegion>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.CountryRegion>, List<Entities.CountryRegion>>(MemberList.None);
        }
    }
}