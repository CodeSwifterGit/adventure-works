using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.Illustration.Queries.GetIllustrations;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.Illustration.Commands.UpdateIllustration
{
    public partial class UpdateIllustrationSetCommand : IRequest<List<IllustrationLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateIllustrationCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseIllustration>, List<UpdateIllustrationCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateIllustrationCommand>, List<Entities.Illustration>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.Illustration>, List<Entities.Illustration>>(MemberList.None);
        }
    }
}