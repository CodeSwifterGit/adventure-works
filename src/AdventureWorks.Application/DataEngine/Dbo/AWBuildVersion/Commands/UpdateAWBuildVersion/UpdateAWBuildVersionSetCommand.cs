using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Dbo.AWBuildVersion.Queries.GetAWBuildVersions;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Dbo;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Dbo;


namespace AdventureWorks.Application.DataEngine.Dbo.AWBuildVersion.Commands.UpdateAWBuildVersion
{
    public partial class UpdateAWBuildVersionSetCommand : IRequest<List<AWBuildVersionLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateAWBuildVersionCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseAWBuildVersion>, List<UpdateAWBuildVersionCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateAWBuildVersionCommand>, List<Entities.AWBuildVersion>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.AWBuildVersion>, List<Entities.AWBuildVersion>>(MemberList.None);
        }
    }
}