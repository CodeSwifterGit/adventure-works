using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.HumanResources;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.Application.DataEngine.HumanResources.Employee.Queries.GetEmployees;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.HumanResources.Employee.Commands.UpdateEmployee
{
    public partial class UpdateEmployeeCommand : BaseEmployee, IRequest<EmployeeLookupModel>, IHaveCustomMapping
    {
        public int EmployeeID { get; set; }
        public string NationalIDNumber { get; set; }
        public int ContactID { get; set; }
        public string LoginID { get; set; }
        public int? ManagerID { get; set; }
        public string Title { get; set; }
        public DateTime BirthDate { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public DateTime HireDate { get; set; }
        public bool SalariedFlag { get; set; }
        public short VacationHours { get; set; }
        public short SickLeaveHours { get; set; }
        public bool CurrentFlag { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateEmployeeRequestTarget RequestTarget { get; set; }

        public UpdateEmployeeCommand()
        {
        }

        public UpdateEmployeeCommand(int employeeID, BaseEmployee model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateEmployeeRequestTarget(employeeID);
        }

        public UpdateEmployeeCommand(int employeeID)
        {
            EmployeeID = employeeID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseEmployee, UpdateEmployeeCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateEmployeeCommand, Entities.Employee>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.Employee, Entities.Employee>(MemberList.None);
        }

        public partial class UpdateEmployeeRequestTarget
        {
            public int EmployeeID { get; set; }

            public UpdateEmployeeRequestTarget()
            {
            }

            public UpdateEmployeeRequestTarget(int employeeID)
            {
                EmployeeID = employeeID;
            }
        }
    }
}