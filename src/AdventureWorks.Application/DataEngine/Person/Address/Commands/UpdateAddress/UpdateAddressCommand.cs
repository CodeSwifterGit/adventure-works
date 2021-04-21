using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Person;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Person;
using AdventureWorks.Application.DataEngine.Person.Address.Queries.GetAddresses;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Person.Address.Commands.UpdateAddress
{
    public partial class UpdateAddressCommand : BaseAddress, IRequest<AddressLookupModel>, IHaveCustomMapping
    {
        public int AddressID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public int StateProvinceID { get; set; }
        public string PostalCode { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateAddressRequestTarget RequestTarget { get; set; }

        public UpdateAddressCommand()
        {
        }

        public UpdateAddressCommand(int addressID, BaseAddress model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateAddressRequestTarget(addressID);
        }

        public UpdateAddressCommand(int addressID)
        {
            AddressID = addressID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseAddress, UpdateAddressCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateAddressCommand, Entities.Address>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.Address, Entities.Address>(MemberList.None);
        }

        public partial class UpdateAddressRequestTarget
        {
            public int AddressID { get; set; }

            public UpdateAddressRequestTarget()
            {
            }

            public UpdateAddressRequestTarget(int addressID)
            {
                AddressID = addressID;
            }
        }
    }
}