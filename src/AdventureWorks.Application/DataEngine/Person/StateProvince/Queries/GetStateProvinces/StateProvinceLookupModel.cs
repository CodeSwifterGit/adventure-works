using System;
using AutoMapper;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.BaseDomain.Entities.Person;
using System.Collections.Generic;
using AdventureWorks.Common.Extensions;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Application.DataEngine.Sales.SalesTaxRate.Queries.GetSalesTaxRates;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritory.Queries.GetSalesTerritories;

namespace AdventureWorks.Application.DataEngine.Person.StateProvince.Queries.GetStateProvinces
{
    public partial class StateProvinceLookupModel : IHaveCustomMapping
    {
        public int StateProvinceID { get; set; }
        public string StateProvinceCode { get; set; }
        public string CountryRegionCode { get; set; }
        public bool IsOnlyStateProvinceFlag { get; set; }
        public string Name { get; set; }
        public int TerritoryID { get; set; }
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
            configuration.CreateMap<Domain.Entities.Person.StateProvince, StateProvinceLookupModel>().IgnoreMissingDestinationMembers().CompensateWithDestinationValues();
            configuration.CreateMap<StateProvinceLookupModel, BaseStateProvince>().IgnoreMissingDestinationMembers();
        }
    }
}
