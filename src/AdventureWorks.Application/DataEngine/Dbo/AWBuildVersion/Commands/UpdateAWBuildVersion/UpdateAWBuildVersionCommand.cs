using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Dbo;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Dbo;
using AdventureWorks.Application.DataEngine.Dbo.AWBuildVersion.Queries.GetAWBuildVersions;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Dbo.AWBuildVersion.Commands.UpdateAWBuildVersion
{
    public partial class UpdateAWBuildVersionCommand : IRequest<AWBuildVersionLookupModel>, IHaveCustomMapping
    {
        public byte SystemInformationID { get; set; }
        public string DatabaseVersion { get; set; }
        public DateTime VersionDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateAWBuildVersionRequestTarget RequestTarget { get; set; }

        public UpdateAWBuildVersionCommand()
        {
        }

        public UpdateAWBuildVersionCommand(byte systemInformationID, BaseAWBuildVersion model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateAWBuildVersionRequestTarget(systemInformationID);
        }

        public UpdateAWBuildVersionCommand(byte systemInformationID)
        {
            SystemInformationID = systemInformationID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseAWBuildVersion, UpdateAWBuildVersionCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateAWBuildVersionCommand, Entities.AWBuildVersion>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.AWBuildVersion, Entities.AWBuildVersion>(MemberList.None);
        }

        public partial class UpdateAWBuildVersionRequestTarget
        {
            public byte SystemInformationID { get; set; }

            public UpdateAWBuildVersionRequestTarget()
            {
            }

            public UpdateAWBuildVersionRequestTarget(byte systemInformationID)
            {
                SystemInformationID = systemInformationID;
            }
        }
    }
}