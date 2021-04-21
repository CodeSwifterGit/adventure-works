using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.HumanResources.Shift.Queries.GetShifts;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.HumanResources;


namespace AdventureWorks.Application.DataEngine.HumanResources.Shift.Commands.UpdateShift
{
    public partial class UpdateShiftSetCommand : IRequest<List<ShiftLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateShiftCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseShift>, List<UpdateShiftCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateShiftCommand>, List<Entities.Shift>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.Shift>, List<Entities.Shift>>(MemberList.None);
        }
    }
}