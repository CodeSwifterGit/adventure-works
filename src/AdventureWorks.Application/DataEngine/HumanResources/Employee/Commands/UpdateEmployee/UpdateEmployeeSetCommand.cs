using System.Collections.Generic;
using AutoMapper;
using AdventureWorks.Application.DataEngine.HumanResources.Employee.Queries.GetEmployees;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.Common.Extensions;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.HumanResources;


namespace AdventureWorks.Application.DataEngine.HumanResources.Employee.Commands.UpdateEmployee
{
    public partial class UpdateEmployeeSetCommand : IRequest<List<EmployeeLookupModel>>,
        IHaveCustomMapping
    {
        public List<UpdateEmployeeCommand> Commands { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<List<BaseEmployee>, List<UpdateEmployeeCommand>>(MemberList.Source)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<UpdateEmployeeCommand>, List<Entities.Employee>>(MemberList.None)
                .IgnoreMissingDestinationMembers();
            configuration.CreateMap<List<Entities.Employee>, List<Entities.Employee>>(MemberList.None);
        }
    }
}