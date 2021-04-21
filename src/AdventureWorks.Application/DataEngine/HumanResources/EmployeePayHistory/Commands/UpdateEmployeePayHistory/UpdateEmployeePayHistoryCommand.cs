using System;
using AutoMapper;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.HumanResources;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Queries.GetEmployeePayHistories;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeePayHistory.Commands.UpdateEmployeePayHistory
{
    public partial class UpdateEmployeePayHistoryCommand : BaseEmployeePayHistory, IRequest<EmployeePayHistoryLookupModel>, IHaveCustomMapping
    {
        public int EmployeeID { get; set; }
        public DateTime RateChangeDate { get; set; }
        public decimal Rate { get; set; }
        public byte PayFrequency { get; set; }
        public DateTime ModifiedDate { get; set; }

        public UpdateEmployeePayHistoryRequestTarget RequestTarget { get; set; }

        public UpdateEmployeePayHistoryCommand()
        {
        }

        public UpdateEmployeePayHistoryCommand(int employeeID, DateTime rateChangeDate, BaseEmployeePayHistory model, IMapper mapper)
        {
            mapper.Map(model, this);
            RequestTarget = new UpdateEmployeePayHistoryRequestTarget(employeeID, rateChangeDate);
        }

        public UpdateEmployeePayHistoryCommand(int employeeID, DateTime rateChangeDate)
        {
            EmployeeID = employeeID;
            RateChangeDate = rateChangeDate;
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseEmployeePayHistory, UpdateEmployeePayHistoryCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<UpdateEmployeePayHistoryCommand, Entities.EmployeePayHistory>(MemberList.None).IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<Entities.EmployeePayHistory, Entities.EmployeePayHistory>(MemberList.None);
        }

        public partial class UpdateEmployeePayHistoryRequestTarget
        {
            public int EmployeeID { get; set; }
            public DateTime RateChangeDate { get; set; }

            public UpdateEmployeePayHistoryRequestTarget()
            {
            }

            public UpdateEmployeePayHistoryRequestTarget(int employeeID, DateTime rateChangeDate)
            {
                EmployeeID = employeeID;
                RateChangeDate = rateChangeDate;
            }
        }
    }
}