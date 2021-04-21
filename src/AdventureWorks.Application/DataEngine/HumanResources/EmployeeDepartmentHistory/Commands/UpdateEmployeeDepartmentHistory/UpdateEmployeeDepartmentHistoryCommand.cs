using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.HumanResources;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Queries.GetEmployeeDepartmentHistories;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Commands.UpdateEmployeeDepartmentHistory
{
    public partial class UpdateEmployeeDepartmentHistoryCommand : BaseEmployeeDepartmentHistory, IRequest<EmployeeDepartmentHistoryLookupModel>, IHaveCustomMapping
    {
        public int EmployeeID { get; set; }
        public short DepartmentID { get; set; }
        public byte ShiftID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateEmployeeDepartmentHistoryRequestTarget RequestTarget { get; set; }

        public UpdateEmployeeDepartmentHistoryCommand()
        {
        }

        public UpdateEmployeeDepartmentHistoryCommand(int employeeID, short departmentID, byte shiftID, DateTime startDate, BaseEmployeeDepartmentHistory model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateEmployeeDepartmentHistoryRequestTarget(employeeID, departmentID, shiftID, startDate);
        }

        public UpdateEmployeeDepartmentHistoryCommand(int employeeID, short departmentID, byte shiftID, DateTime startDate)
        {
            EmployeeID = employeeID;
            DepartmentID = departmentID;
            ShiftID = shiftID;
            StartDate = startDate;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseEmployeeDepartmentHistory, UpdateEmployeeDepartmentHistoryCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateEmployeeDepartmentHistoryCommand, Entities.EmployeeDepartmentHistory>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.EmployeeDepartmentHistory, Entities.EmployeeDepartmentHistory>(MemberList.None);
        }

        public partial class UpdateEmployeeDepartmentHistoryRequestTarget
        {
            public int EmployeeID { get; set; }
            public short DepartmentID { get; set; }
            public byte ShiftID { get; set; }
            public DateTime StartDate { get; set; }

            public UpdateEmployeeDepartmentHistoryRequestTarget()
            {
            }

            public UpdateEmployeeDepartmentHistoryRequestTarget(int employeeID, short departmentID, byte shiftID, DateTime startDate)
            {
                EmployeeID = employeeID;
                DepartmentID = departmentID;
                ShiftID = shiftID;
                StartDate = startDate;
            }
        }
    }
}