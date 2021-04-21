using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.UnitMeasure.Queries.GetUnitMeasures;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.UnitMeasure.Commands.UpdateUnitMeasure
{
    public partial class UpdateUnitMeasureSetCommand : IRequest<List<UnitMeasureLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateUnitMeasureCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseUnitMeasure>, List<UpdateUnitMeasureCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateUnitMeasureCommand>, List<Entities.UnitMeasure>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.UnitMeasure>, List<Entities.UnitMeasure>>(MemberList.None);
        }
    }
}