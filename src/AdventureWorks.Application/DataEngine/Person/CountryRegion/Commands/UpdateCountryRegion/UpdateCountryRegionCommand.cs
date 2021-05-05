using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Person;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Person;
using AdventureWorks.Application.DataEngine.Person.CountryRegion.Queries.GetCountryRegions;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Person.CountryRegion.Commands.UpdateCountryRegion
{
    public partial class UpdateCountryRegionCommand : IRequest<CountryRegionLookupModel>, IHaveCustomMapping
    {
        public string CountryRegionCode { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateCountryRegionRequestTarget RequestTarget { get; set; }

        public UpdateCountryRegionCommand()
        {
        }

        public UpdateCountryRegionCommand(string countryRegionCode, BaseCountryRegion model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateCountryRegionRequestTarget(countryRegionCode);
        }

        public UpdateCountryRegionCommand(string countryRegionCode)
        {
            CountryRegionCode = countryRegionCode;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseCountryRegion, UpdateCountryRegionCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateCountryRegionCommand, Entities.CountryRegion>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.CountryRegion, Entities.CountryRegion>(MemberList.None);
        }

        public partial class UpdateCountryRegionRequestTarget
        {
            public string CountryRegionCode { get; set; }

            public UpdateCountryRegionRequestTarget()
            {
            }

            public UpdateCountryRegionRequestTarget(string countryRegionCode)
            {
                CountryRegionCode = countryRegionCode;
            }
        }
    }
}