using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.HumanResources;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Queries.GetEmployeeAddresses;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Commands.UpdateEmployeeAddress
{
    public partial class UpdateEmployeeAddressCommand : IRequest<EmployeeAddressLookupModel>, IHaveCustomMapping
    {
        public int EmployeeID { get; set; }
        public int AddressID { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateEmployeeAddressRequestTarget RequestTarget { get; set; }

        public UpdateEmployeeAddressCommand()
        {
        }

        public UpdateEmployeeAddressCommand(int employeeID, int addressID, BaseEmployeeAddress model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateEmployeeAddressRequestTarget(employeeID, addressID);
        }

        public UpdateEmployeeAddressCommand(int employeeID, int addressID)
        {
            EmployeeID = employeeID;
            AddressID = addressID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseEmployeeAddress, UpdateEmployeeAddressCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateEmployeeAddressCommand, Entities.EmployeeAddress>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.EmployeeAddress, Entities.EmployeeAddress>(MemberList.None);
        }

        public partial class UpdateEmployeeAddressRequestTarget
        {
            public int EmployeeID { get; set; }
            public int AddressID { get; set; }

            public UpdateEmployeeAddressRequestTarget()
            {
            }

            public UpdateEmployeeAddressRequestTarget(int employeeID, int addressID)
            {
                EmployeeID = employeeID;
                AddressID = addressID;
            }
        }
    }
}