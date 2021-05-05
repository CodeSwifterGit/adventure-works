using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Application.DataEngine.Production.UnitMeasure.Queries.GetUnitMeasures;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.UnitMeasure.Commands.UpdateUnitMeasure
{
    public partial class UpdateUnitMeasureCommand : IRequest<UnitMeasureLookupModel>, IHaveCustomMapping
    {
        public string UnitMeasureCode { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateUnitMeasureRequestTarget RequestTarget { get; set; }

        public UpdateUnitMeasureCommand()
        {
        }

        public UpdateUnitMeasureCommand(string unitMeasureCode, BaseUnitMeasure model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateUnitMeasureRequestTarget(unitMeasureCode);
        }

        public UpdateUnitMeasureCommand(string unitMeasureCode)
        {
            UnitMeasureCode = unitMeasureCode;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseUnitMeasure, UpdateUnitMeasureCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateUnitMeasureCommand, Entities.UnitMeasure>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.UnitMeasure, Entities.UnitMeasure>(MemberList.None);
        }

        public partial class UpdateUnitMeasureRequestTarget
        {
            public string UnitMeasureCode { get; set; }

            public UpdateUnitMeasureRequestTarget()
            {
            }

            public UpdateUnitMeasureRequestTarget(string unitMeasureCode)
            {
                UnitMeasureCode = unitMeasureCode;
            }
        }
    }
}