using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Person;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Person;
using AdventureWorks.Application.DataEngine.Person.StateProvince.Queries.GetStateProvinces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Person.StateProvince.Commands.UpdateStateProvince
{
    public partial class UpdateStateProvinceCommand : IRequest<StateProvinceLookupModel>, IHaveCustomMapping
    {
        public int StateProvinceID { get; set; }
        public string StateProvinceCode { get; set; }
        public string CountryRegionCode { get; set; }
        public bool IsOnlyStateProvinceFlag { get; set; }
        public string Name { get; set; }
        public int TerritoryID { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateStateProvinceRequestTarget RequestTarget { get; set; }

        public UpdateStateProvinceCommand()
        {
        }

        public UpdateStateProvinceCommand(int stateProvinceID, BaseStateProvince model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateStateProvinceRequestTarget(stateProvinceID);
        }

        public UpdateStateProvinceCommand(int stateProvinceID)
        {
            StateProvinceID = stateProvinceID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseStateProvince, UpdateStateProvinceCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateStateProvinceCommand, Entities.StateProvince>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.StateProvince, Entities.StateProvince>(MemberList.None);
        }

        public partial class UpdateStateProvinceRequestTarget
        {
            public int StateProvinceID { get; set; }

            public UpdateStateProvinceRequestTarget()
            {
            }

            public UpdateStateProvinceRequestTarget(int stateProvinceID)
            {
                StateProvinceID = stateProvinceID;
            }
        }
    }
}