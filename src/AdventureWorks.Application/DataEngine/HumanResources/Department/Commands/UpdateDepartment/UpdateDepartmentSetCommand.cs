using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.HumanResources.Department.Queries.GetDepartments;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.HumanResources;


namespace AdventureWorks.Application.DataEngine.HumanResources.Department.Commands.UpdateDepartment
{
    public partial class UpdateDepartmentSetCommand : IRequest<List<DepartmentLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateDepartmentCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseDepartment>, List<UpdateDepartmentCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateDepartmentCommand>, List<Entities.Department>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.Department>, List<Entities.Department>>(MemberList.None);
        }
    }
}