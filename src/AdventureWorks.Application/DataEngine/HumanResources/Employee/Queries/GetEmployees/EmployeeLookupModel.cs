using System;
using AutoMapper;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.Common.Extensions;
// ReSharper disable InconsistentNaming

namespace AdventureWorks.Application.DataEngine.HumanResources.Employee.Queries.GetEmployees
{
    public partial class EmployeeLookupModel : IHaveCustomMapping
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

        #region Navigation Properties

        // Uncomment the following line if you need child navigation properties (can cause a poor performance)
        /*  */
        // Uncomment the following line if you need parent navigation properties
        /*  */
        #endregion

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Domain.Entities.HumanResources.Employee, EmployeeLookupModel>().IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<EmployeeLookupModel, BaseEmployee>().IgnoreMissingDestinationMembers();
        }
    }
}
