using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Application.DataEngine.Production.Illustration.Queries.GetIllustrations;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.Illustration.Commands.UpdateIllustration
{
    public partial class UpdateIllustrationCommand : IRequest<IllustrationLookupModel>, IHaveCustomMapping
    {
        public int IllustrationID { get; set; }
        public string Diagram { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateIllustrationRequestTarget RequestTarget { get; set; }

        public UpdateIllustrationCommand()
        {
        }

        public UpdateIllustrationCommand(int illustrationID, BaseIllustration model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateIllustrationRequestTarget(illustrationID);
        }

        public UpdateIllustrationCommand(int illustrationID)
        {
            IllustrationID = illustrationID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseIllustration, UpdateIllustrationCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateIllustrationCommand, Entities.Illustration>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.Illustration, Entities.Illustration>(MemberList.None);
        }

        public partial class UpdateIllustrationRequestTarget
        {
            public int IllustrationID { get; set; }

            public UpdateIllustrationRequestTarget()
            {
            }

            public UpdateIllustrationRequestTarget(int illustrationID)
            {
                IllustrationID = illustrationID;
            }
        }
    }
}