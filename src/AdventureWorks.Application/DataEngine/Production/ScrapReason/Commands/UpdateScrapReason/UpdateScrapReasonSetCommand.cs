using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ScrapReason.Queries.GetScrapReasons;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.ScrapReason.Commands.UpdateScrapReason
{
    public partial class UpdateScrapReasonSetCommand : IRequest<List<ScrapReasonLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateScrapReasonCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseScrapReason>, List<UpdateScrapReasonCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateScrapReasonCommand>, List<Entities.ScrapReason>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.ScrapReason>, List<Entities.ScrapReason>>(MemberList.None);
        }
    }
}