using System;
using AutoMapper;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using System.Collections.Generic;
using AdventureWorks.Common.Extensions;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Queries.GetEmployeeDepartmentHistories
{
    public partial class EmployeeDepartmentHistoryLookupModel : IHaveCustomMapping
    {
        public int EmployeeID { get; set; }
        public short DepartmentID { get; set; }
        public byte ShiftID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        #region Navigation Properties

        // Uncomment the following line if you need child navigation properties (can cause a poor performance)
        /*  */
        // Uncomment the following line if you need parent navigation properties
        /*  */
        #endregion

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Domain.Entities.HumanResources.EmployeeDepartmentHistory, EmployeeDepartmentHistoryLookupModel>().IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<EmployeeDepartmentHistoryLookupModel, BaseEmployeeDepartmentHistory>().IgnoreMissingDestinationMembers();
        }
    }
}
