using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.HumanResources;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.Application.DataEngine.HumanResources.Shift.Queries.GetShifts;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.HumanResources.Shift.Commands.UpdateShift
{
    public partial class UpdateShiftCommand : BaseShift, IRequest<ShiftLookupModel>, IHaveCustomMapping
    {
        public byte ShiftID { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateShiftRequestTarget RequestTarget { get; set; }

        public UpdateShiftCommand()
        {
        }

        public UpdateShiftCommand(byte shiftID, BaseShift model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateShiftRequestTarget(shiftID);
        }

        public UpdateShiftCommand(byte shiftID)
        {
            ShiftID = shiftID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseShift, UpdateShiftCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateShiftCommand, Entities.Shift>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.Shift, Entities.Shift>(MemberList.None);
        }

        public partial class UpdateShiftRequestTarget
        {
            public byte ShiftID { get; set; }

            public UpdateShiftRequestTarget()
            {
            }

            public UpdateShiftRequestTarget(byte shiftID)
            {
                ShiftID = shiftID;
            }
        }
    }
}