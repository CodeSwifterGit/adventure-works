using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.Culture.Queries.GetCultures;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.Culture.Commands.UpdateCulture
{
    public partial class UpdateCultureSetCommand : IRequest<List<CultureLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateCultureCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseCulture>, List<UpdateCultureCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateCultureCommand>, List<Entities.Culture>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.Culture>, List<Entities.Culture>>(MemberList.None);
        }
    }
}