using System;
using AutoMapper;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using System.Collections.Generic;
using AdventureWorks.Common.Extensions;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Application.DataEngine.Person.Contact.Queries.GetContacts;
using AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderHeader.Queries.GetPurchaseOrderHeaders;
using AdventureWorks.Application.DataEngine.Sales.SalesPerson.Queries.GetSalesPeople;

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
