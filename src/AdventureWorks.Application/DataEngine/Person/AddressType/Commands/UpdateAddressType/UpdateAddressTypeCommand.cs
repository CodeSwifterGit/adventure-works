using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Person;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Person;
using AdventureWorks.Application.DataEngine.Person.AddressType.Queries.GetAddressTypes;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Person.AddressType.Commands.UpdateAddressType
{
    public partial class UpdateAddressTypeCommand : BaseAddressType, IRequest<AddressTypeLookupModel>, IHaveCustomMapping
    {
        public int AddressTypeID { get; set; }
        public string Name { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateAddressTypeRequestTarget RequestTarget { get; set; }

        public UpdateAddressTypeCommand()
        {
        }

        public UpdateAddressTypeCommand(int addressTypeID, BaseAddressType model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateAddressTypeRequestTarget(addressTypeID);
        }

        public UpdateAddressTypeCommand(int addressTypeID)
        {
            AddressTypeID = addressTypeID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseAddressType, UpdateAddressTypeCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateAddressTypeCommand, Entities.AddressType>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.AddressType, Entities.AddressType>(MemberList.None);
        }

        public partial class UpdateAddressTypeRequestTarget
        {
            public int AddressTypeID { get; set; }

            public UpdateAddressTypeRequestTarget()
            {
            }

            public UpdateAddressTypeRequestTarget(int addressTypeID)
            {
                AddressTypeID = addressTypeID;
            }
        }
    }
}