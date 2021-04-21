using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Application.DataEngine.Production.ScrapReason.Queries.GetScrapReasons;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.ScrapReason.Commands.UpdateScrapReason
{
    public partial class UpdateScrapReasonCommand : BaseScrapReason, IRequest<ScrapReasonLookupModel>, IHaveCustomMapping
    {
        public short ScrapReasonID { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateScrapReasonRequestTarget RequestTarget { get; set; }

        public UpdateScrapReasonCommand()
        {
        }

        public UpdateScrapReasonCommand(short scrapReasonID, BaseScrapReason model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateScrapReasonRequestTarget(scrapReasonID);
        }

        public UpdateScrapReasonCommand(short scrapReasonID)
        {
            ScrapReasonID = scrapReasonID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseScrapReason, UpdateScrapReasonCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateScrapReasonCommand, Entities.ScrapReason>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.ScrapReason, Entities.ScrapReason>(MemberList.None);
        }

        public partial class UpdateScrapReasonRequestTarget
        {
            public short ScrapReasonID { get; set; }

            public UpdateScrapReasonRequestTarget()
            {
            }

            public UpdateScrapReasonRequestTarget(short scrapReasonID)
            {
                ScrapReasonID = scrapReasonID;
            }
        }
    }
}