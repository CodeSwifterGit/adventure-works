using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.HumanResources;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.Application.DataEngine.HumanResources.Department.Queries.GetDepartments;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.HumanResources.Department.Commands.UpdateDepartment
{
    public partial class UpdateDepartmentCommand : BaseDepartment, IRequest<DepartmentLookupModel>, IHaveCustomMapping
    {
        public short DepartmentID { get; set; }
        public string Name { get; set; }
        public string GroupName { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateDepartmentRequestTarget RequestTarget { get; set; }

        public UpdateDepartmentCommand()
        {
        }

        public UpdateDepartmentCommand(short departmentID, BaseDepartment model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateDepartmentRequestTarget(departmentID);
        }

        public UpdateDepartmentCommand(short departmentID)
        {
            DepartmentID = departmentID;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseDepartment, UpdateDepartmentCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateDepartmentCommand, Entities.Department>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.Department, Entities.Department>(MemberList.None);
        }

        public partial class UpdateDepartmentRequestTarget
        {
            public short DepartmentID { get; set; }

            public UpdateDepartmentRequestTarget()
            {
            }

            public UpdateDepartmentRequestTarget(short departmentID)
            {
                DepartmentID = departmentID;
            }
        }
    }
}